using System.Web.Security;
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
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any())
            {
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Developer"));
                roleManager.Create(new IdentityRole("Enhancement"));
            }
            if (!context.Users.Any())
            {
                var tesuansey = new User
                {
                    FirstName = "Te'suansey",
                    LastName = "Link",
                    City = "Hope",
                    Email = "tesuanseylink@gmail.com",
                    DateOfBirth = new DateTime(03/29/1985),
                };


                var reid = new User
                {
                    FirstName = "Reid",
                    LastName = "Hanna",
                    City = "Little Rock",
                    Email = "annahdier@gmail.com",
                    DateOfBirth = new DateTime(09/11/1988),
                };

                var benji = new User
                {
                    FirstName = "Benji",
                    LastName = "Hardy",
                    City = "Mulberry",
                    Email = "benjayhardy@gmail.com",
                    DateOfBirth = new DateTime(04/18/1985),
                };

                var chasmine = new User
                {
                    FirstName = "Chasmine",
                    LastName = "Alexander",
                    City = "Benton",
                    Email = "cbalexander7982@gmail.com",
                    DateOfBirth = new DateTime(09/10/1991)

                }
                ;

                userManager.Create(tesuansey, "Be@uchamp1");
                userManager.Create(reid, "J0nesbeach!");
                userManager.Create(benji, "B!anched0g");
                userManager.Create(chasmine, "C@yson123");

                

                //Roles.AddUserToRole("tesuanseylink@gmail.com", "Admin");
                //Roles.AddUserToRole("annahdier@gmail.com", "Developer");
                //Roles.AddUserToRole("benjayhardy@gmail.com", "Developer");
                //Roles.AddUserToRole("cbalexander7982@gmail.com", "Enhancement");

                context.SaveChanges();
            }
        }
    }
}
