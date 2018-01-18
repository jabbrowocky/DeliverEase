using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliverEase.Models;
using Microsoft.AspNet.Identity;

namespace DeliverEase.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
                      
            
            
            return View();
        }
        public ActionResult SelectRestaurant()
        {
            var rest = db.Restaurants.ToList();
            return View(rest);
        }
        public ActionResult SelectMenuItems(int? id)
        {
            // string userId = User.Identity.GetUserId();

            var menuItems = db.Menus.Where(m => m.RestaurantId == id).ToList();

            return View(menuItems);
        }
        // [HttpPost]
        public ActionResult AddItem(Menu item)
            {
            
            
            item = db.Menus.Where(m => m.Id == item.Id).First();
            Restaurant rest = db.Restaurants.Where(r => r.RestaurantId == item.RestaurantId).First();
            Order order = new Order();
            order.menuItemId = item;
            string userId = User.Identity.GetUserId();
            order.CustomerId = db.Customers.Where(c => c.UserId == userId).First().Id;
            order.OrderDetails = order.menuItemId.MenuItem;
            order.OrderCost = order.menuItemId.ItemPrice;
            bool deliveryExisted = false;
            foreach (ToDeliver del in db.ToDelivers)
            {
                if (del.CustomerId == order.CustomerId && del.IsComplete == false && order.IsSubmitted == false && order.IsAdded == false)
                {
                    order.ToDeliverId = del.Id;
                    deliveryExisted = true;
                    break;
                    
                }
                //else
                //{
                //    ToDeliver delivery = new ToDeliver();
                //    delivery.CustomerId = order.CustomerId;
                //    db.ToDelivers.Add(delivery);
                //    db.SaveChanges();
                //    order.ToDeliverId = delivery.Id;
                //}
            }
            if (db.ToDelivers.Count().Equals(0) || !deliveryExisted)
            {
                ToDeliver delivery = new ToDeliver();
                delivery.CustomerId = order.CustomerId;
                db.ToDelivers.Add(delivery);
                db.SaveChanges();
                order.ToDeliverId = delivery.Id;
            }
            order.IsAdded = true;
            db.Orders.Add(order);

            db.SaveChanges();

            return RedirectToAction("SelectMenuItems", new { id = rest.RestaurantId});
        }
        public ActionResult SubmitOrder(int? id)
        {
            foreach(Order order in db.Orders)
            {
                if(order.CustomerId == id)
                {
                    order.IsSubmitted = true;
                    ToDeliver del = db.ToDelivers.Where(d => d.Id == order.ToDeliverId).First();
                    del.IsComplete = true;
                }
            }
            db.SaveChanges();
            return View("SubmitOrder");
        }
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerId,OrderDetails,OrderCost")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", order.CustomerId);
            return View(order);
        }

        
        public ActionResult ViewOrders()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                Customer customer = db.Customers.Where(c => c.UserId == userId).First();
                var order = db.Orders
                    .Where(o => o.CustomerId == customer.Id)
                    .Where(o => o.IsAccepted == false)
                    .Where(o => o.IsSubmitted == false)
                    .ToList();

                return View(order);
            }
            return RedirectToAction("Login","Account");
        }
        public ActionResult Edit(int? id, int? custId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
      
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("ViewOrders","Orders");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
