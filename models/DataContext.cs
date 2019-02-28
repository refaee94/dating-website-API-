using Microsoft.EntityFrameworkCore;
using dating_app.models;

namespace dating_app.models {
    public class StoreAppContext: DbContext {
        protected StoreAppContext(){}
        public StoreAppContext(DbContextOptions<StoreAppContext>options):base(options) {}
        public DbSet<user> users {get; set;}
                public DbSet<value> values {get; set;}

    }
}
