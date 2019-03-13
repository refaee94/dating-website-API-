using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using backend.helper;
using dating_app.models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SportsStore2 {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            var key = Encoding.ASCII.GetBytes ("super secret key");

            services.AddDbContext<StoreAppContext> (options => options.UseSqlServer (Configuration.GetConnectionString ("SportsStoreDb")));
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
            services.AddCors ();
            services.AddScoped<authrepositry, authrepo> ();
            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme).AddJwtBearer (option => {

                option.TokenValidationParameters = new TokenValidationParameters {

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey (key),
                ValidateAudience = false,
                ValidateIssuer = false

                };

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, StoreAppContext storeAppContext) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
                app.UseExceptionHandler (builder => {
                    builder.Run (async context => {

                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature> ();
                        if (error != null) {
                            
                            context.Response.AddApplicationError(error.Error.Message);

                            await context.Response.WriteAsync (error.Error.Message);
                        }

                    });

                });
            }
            app.UseCors (x => x.AllowAnyHeader ().AllowAnyMethod ().AllowAnyOrigin ().AllowCredentials ());
            //app.UseHttpsRedirection();
            app.UseDefaultFiles ();
            app.UseStaticFiles ();
            app.UseAuthentication ();

            app.UseMvc ();
            StoreDbContextExtensions.CreateSeedData (storeAppContext);
        }
    }
}