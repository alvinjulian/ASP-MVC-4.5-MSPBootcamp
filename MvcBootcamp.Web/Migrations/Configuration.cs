namespace MvcBootcamp.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MvcBootcamp.Web.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<MvcBootcamp.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //agar bisa diupdate databasenya
        }

        protected override void Seed(MvcBootcamp.Web.Models.ApplicationDbContext context) //akan dijalankan saat update database
        {
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

            if (!context.Users.Any(u=>u.UserName == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);


                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = "admin" };
                userManager.Create(user, "admin123.");
                roleManager.Create(new IdentityRole { Name = "Administrator" });
                userManager.AddToRole(user.Id, "Administrator");
            }
            if (!context.Users.Any(u => u.UserName == "user"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);


                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = "user" };
                userManager.Create(user, "user123.");
                roleManager.Create(new IdentityRole { Name = "Members" });
                userManager.AddToRole(user.Id, "Members");
            }
        }
    }
}
