using Authentication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authentication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Authentication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Authentication.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
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
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Developer" },
                new IdentityRole { Name = "Elf" }
            );

            if (!context.Users.Any())
            {
                var tesuansey = new ApplicationUser
                {
                    FirstName = "Tesuansey",
                    LastName = "Link",
                    City = "Hope",
                    Email = "tesuanseylink@gmail.com",
                    DateOfBirth = new DateTime(03/29/1985),
                };

                var reid = new ApplicationUser
                {
                    FirstName = "Reid",
                    LastName = "Hanna",
                    City = "Little Rock",
                    Email = "annahdier@gmail.com",
                    DateOfBirth = new DateTime(09/11/1988),
                };
                var benji = new ApplicationUser
                {
                    FirstName = "benji",
                    LastName = "Hardy",
                    City = "Mulberry",
                    Email = "benjayhardy@gmail.com",
                    DateOfBirth = new DateTime(04/18/1985),
                };

                
                userManager.Create(tesuansey, "Be@uchamp1");
                userManager.Create(reid, "J0nesbeach!");
                userManager.Create(benji, "B1anched0g");

                context.SaveChanges();
            }

        }
    }
}
