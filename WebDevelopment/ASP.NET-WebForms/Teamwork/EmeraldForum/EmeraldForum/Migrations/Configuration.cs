namespace EmeraldForum.Migrations
{
    using EmeraldForum.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmeraldForum.Models.ForumEmeraldContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EmeraldForum.Models.ForumEmeraldContext context)
        {
            var adminRole = new Role();
            adminRole.Id = "1";
            adminRole.Name = "Administrator";
            context.Roles.AddOrUpdate(x => x.Name, adminRole);

            var userRole = new Role();
            userRole.Id = "2";
            userRole.Name = "User";
            context.Roles.AddOrUpdate(x => x.Name, userRole);

            var bannedRole = new Role();
            bannedRole.Id = "3";
            bannedRole.Name = "Banned";
            context.Roles.AddOrUpdate(x => x.Name, bannedRole);

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
