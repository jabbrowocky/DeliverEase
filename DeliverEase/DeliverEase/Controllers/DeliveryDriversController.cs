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
    public class DeliveryDriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryDrivers
        public ActionResult Index()
        {
            string uId = User.Identity.GetUserId();
            DeliveryDriver dri = db.DeliveryDrivers.Where(d => d.UserId == uId).First();
            if (dri.HasDelivery)
            {
                dri = db.DeliveryDrivers.Where(d => d.UserId == uId).Include(u => u.Delivery).FirstOrDefault();
                return RedirectToAction("AcceptDel", new { id = dri.Delivery.Id });
            }
            return View(dri);
              
        }
        public ActionResult AcceptDel(int? id)
        {
            string uId = User.Identity.GetUserId();
            DeliveryDriver drivey = db.DeliveryDrivers.Where(u => u.UserId == uId).FirstOrDefault();
            drivey.HasDelivery = true;
            ToDeliver del = db.ToDelivers.Where(u => u.Id == id).Include(u=>u.Rest).Include(u=>u.Items).FirstOrDefault();
            del.IsAccepted = true;
            drivey.Delivery = del;
            db.SaveChanges();
            NavigationModel model = new NavigationModel()
            {
                Delivery = del,
                Driver = drivey

            };
            return View(model);
        }
        public ActionResult CompleteDel(int? id)
        {
            string uId = User.Identity.GetUserId();
            DeliveryDriver drivey = db.DeliveryDrivers.Where(u => u.UserId == uId).Include(u=>u.Delivery).First();
            drivey.HasDelivery = false;
            drivey.Delivery.IsDelivered = true;
            drivey.Delivery = null;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PendingDeliveries()
        {
            string uId = User.Identity.GetUserId();
            DriverViewModel model = new DriverViewModel()
            {
                Driver = db.DeliveryDrivers.Where(i => i.UserId == uId).First(),
                PendingDels = db.ToDelivers.Where(u => u.IsComplete == true).Where(u=>u.IsAccepted == false).Where(u=>u.IsDelivered == false).Include(u => u.Items).ToList()

            };
            
            
            return View(model);
        }
        public ActionResult ViewDel (int? id)
        {
            ToDeliver del = db.ToDelivers.Where(u => u.Id == id).Where(u => u.IsComplete == true).Include(u=>u.Items).Include( u => u.Rest).First();
            
            return View(del);
        }

        // GET: DeliveryDrivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDriver deliveryDriver = db.DeliveryDrivers.Find(id);
            if (deliveryDriver == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDriver);
        }

        // GET: DeliveryDrivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,DriverFirstName,DriverLastName")] DeliveryDriver deliveryDriver)
        {
            string userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                deliveryDriver.UserId = userId;
                db.DeliveryDrivers.Add(deliveryDriver);
                db.SaveChanges();
                return RedirectToAction("Index","DeliveryDrivers", new { m = deliveryDriver });
            }

            return View("Index");
        }

        // GET: DeliveryDrivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDriver deliveryDriver = db.DeliveryDrivers.Find(id);
            if (deliveryDriver == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDriver);
        }

        // POST: DeliveryDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,DriverFirstName,DriverLastName")] DeliveryDriver deliveryDriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryDriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryDriver);
        }

        // GET: DeliveryDrivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDriver deliveryDriver = db.DeliveryDrivers.Find(id);
            if (deliveryDriver == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDriver);
        }

        // POST: DeliveryDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryDriver deliveryDriver = db.DeliveryDrivers.Find(id);
            db.DeliveryDrivers.Remove(deliveryDriver);
            db.SaveChanges();
            return RedirectToAction("Index");
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
