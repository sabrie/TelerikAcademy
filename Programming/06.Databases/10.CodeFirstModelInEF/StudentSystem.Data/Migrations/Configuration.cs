namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //context.Students.AddOrUpdate(
            //    s => s.FullName,
            //    new Student { FullName = "Svetlin Nakov", Number = "12345" },
            //    new Student { FullName = "Doncho Minkov", Number = "34567" },
            //    new Student { FullName = "Niki Kostov", Number = "25689" }
            //);

            //context.Students.AddOrUpdate(
            //    s => s.FullName,
            //    new Student { FullName = "Svetlin Nakov", Number = "12345" },
            //    new Student { FullName = "Doncho Minkov", Number = "34567" },
            //    new Student { FullName = "Niki Kostov", Number = "25689" }
            //);
        }
    }
}
