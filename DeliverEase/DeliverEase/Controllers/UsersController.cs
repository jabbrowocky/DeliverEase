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
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index(string role)
        {
            
            var user = User.Identity;
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var s = UserManager.GetRoles(user.GetUserId());
            
            string userId = User.Identity.GetUserId();
            if (isAdminUser())
            {
                
                return View("Admin");
            }
            else if ( s[0].ToString() == "Customer" || role == "Customer")
            {                
                foreach(Customer customer in context.Customers)
                {
                    if (customer.UserId == userId)
                    {
                        return RedirectToAction("Index","Customers");
                    }
                    else
                    {
                        return RedirectToAction("Create", "Customers");
                    }
                }
                return RedirectToAction("Create", "Customers");
            }
            else if (s[0].ToString() == "Restaurant" || role == "Restaurant")
            {
                return View("Restaurant");
            }
            else if (s[0].ToString() == "DeliveryDriver" || role == "DeliveryDriver")
            {
                foreach (DeliveryDriver driver in context.DeliveryDrivers)
                {
                    if (driver.UserId == userId)
                    {
                        return RedirectToAction("Index", "DeliveryDrivers");
                    }
                    else
                    {
                        return RedirectToAction("Create", "DeliveryDrivers");
                    }
                }
                return RedirectToAction("Create", "DeliveryDrivers");
            }
            return RedirectToAction("Index", "Home");

        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
               
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