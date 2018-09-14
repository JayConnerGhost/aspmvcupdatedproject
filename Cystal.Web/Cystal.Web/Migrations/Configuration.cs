namespace Cystal.Web.Migrations
{
    using Cystal.Web.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cystal.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Cystal.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(Cystal.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == "GlobalAdmin"))
            {
               
                var role = new IdentityRole { Name = "GlobalAdmin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Client"))
            {
                var role = new IdentityRole { Name = "Client" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@test.com"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = "admin@test.com",
                    Email="admin@test.com"
                    
                };

                userManager.Create(user, "Password#1");
                userManager.AddToRole(user.Id, "GlobalAdmin");
            }
        }



    
    }
}
