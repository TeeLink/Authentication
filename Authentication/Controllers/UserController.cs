using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication.Models;
using Microsoft.AspNet.Identity;

namespace Authentication.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = db.Users.ToList().Select(u => new InfoViewModel()
            {
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                City = u.City,
                DateOfBirth = u.DateOfBirth
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Info()
        {
            
                
                var currentUser = db.Users.Find(User.Identity.GetUserId());
                var model = new InfoViewModel()
                {
                   Email = currentUser.Email,
                   FirstName = currentUser.FirstName,
                   LastName = currentUser.LastName,
                   City = currentUser.City,
                   DateOfBirth = currentUser.DateOfBirth
                };

                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }


    }

