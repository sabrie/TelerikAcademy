using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.DataLayer;
using Students.DataLayer.Migrations;
using Students.Models;

namespace Students.DbInitializerClient
{
    public class StudentsDbInitializer
    {
        static void Main()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<StudentsContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<StudentsContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsContext, Configuration>());

            using (var db = new StudentsContext())
            {
                db.Database.Initialize(force: true);
            }
        }
    }
}
