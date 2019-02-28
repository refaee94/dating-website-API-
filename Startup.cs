using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dating_app.models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace SportsStore2 {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<StoreAppContext> (options => options.UseSqlServer (Configuration.GetConnectionString ("SportsStoreDb")));
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
            services.AddCors();
            services.AddScoped<authrepositry,authrepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env,StoreAppContext storeAppContext) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }
app.UseCors(x=> x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            //app.UseHttpsRedirection();
            app.UseDefaultFiles ();
            app.UseStaticFiles ();
            app.UseMvc ();
                        StoreDbContextExten