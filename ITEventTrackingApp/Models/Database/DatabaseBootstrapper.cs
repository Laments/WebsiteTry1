using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITEventTrackingApp.Models.DatabaseModel;

namespace ITEventTrackingApp.Models.Database
{
    // basic idea: http://stackoverflow.com/questions/19920444/entity-framework-code-first-check-database-exist
    // modeled after http://stackoverflow.com/questions/13198869/is-there-a-command-to-check-to-see-if-a-database-exists-from-entity-framework
    public class DatabaseBootstrapper
    {

        private DatabaseTables context;

        public DatabaseBootstrapper(DatabaseTables dbContext)
        {
            context = dbContext;
        }

        public void Configure()
        {
            if (context.Database.Exists())
                return;

            context.Database.CreateIfNotExists();
            DatabaseModel.Seeder.SeedDatabase(context);
        }
    }
}