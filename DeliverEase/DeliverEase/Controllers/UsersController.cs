using DeliverEase.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliverEase.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users

        public ActionResult Index(string role)
        {

            var user = User.Identity;

            if (isAdminUser())
            {
                return View("Admin");
            }
            else if (User.IsInRole("Customer") || role == "Customer")
            {
               
                return View("Customer");
            }
            else if (User.IsInRole("Restaurant") || role == "Restaurant")
            {
                return View("Restaurant");
            }
            else if (User.IsInRole("DeliveryDriver") || role == "DeliveryDriver")
            {
                return View("DeliveryDriver");
            }
            return RedirectToAction("Index", "Home");

        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
       
    }
}