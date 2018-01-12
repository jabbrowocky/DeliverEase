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
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            
            return View();
        }
        
    }
}