using BloggingSystem.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.DbInitializerClient
{
    class DbInitializer
    {
        static void Main()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<BloggingSystemContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<BloggingSystemContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsContext, Configuration>());

            using (var context = new BloggingSystemContext())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}
