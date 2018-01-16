using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliverEase.Models;

namespace DeliverEase.Controllers
{
    public class DeliveryDriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryDrivers
        public ActionResult Index()
        {
            return View(db.DeliveryDrivers.ToList());
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
            if (ModelState.IsValid)
            {
                db.DeliveryDrivers.Add(deliveryDriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryDriver);
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
