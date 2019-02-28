using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dating_app.models {
    public static class StoreDbContextExtensions {
        public static void CreateSeedData (this StoreAppContext context) {
            if (context.Database.GetMigrations ().Count () > 0 &&
                context.Database.GetPendingMigrations ().Count () == 0 &&
                context.values.Count () == 0) {
                var v1 = new value {
                name = "value1",
               
                };
                var v2 = new value {
                name = "value2",
               
                };
context.values.AddRange(v1,v2);
                              context.SaveChanges ();


            }

        }
    }
}