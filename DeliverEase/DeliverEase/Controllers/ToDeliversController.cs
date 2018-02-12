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
    public class ToDeliversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToDelivers
        public ActionResult Index()
        {
            
            return View(db.ToDelivers.Where(u=>u.IsComplete == true).ToList());
        }

        // GET: ToDelivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDeliver toDeliver = db.ToDelivers.Find(id);
            if (toDeliver == null)
            {
                return HttpNotFound();
            }
            return View(toDeliver);
        }

        // GET: ToDelivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDelivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CustomerId,IsDelivered,IsAccepted")] ToDeliver toDeliver)
        {
            if (ModelState.IsValid)
            {
                db.ToDelivers.Add(toDeliver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDeliver);
        }

        // GET: ToDelivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDeliver toDeliver = db.ToDelivers.Find(id);
            if (toDeliver == null)
            {
                return HttpNotFound();
            }
            return View(toDeliver);
        }

        // POST: ToDelivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CustomerId,IsDelivered,IsAccepted")] ToDeliver toDeliver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDeliver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDeliver);
        }

        // GET: ToDelivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDeliver toDeliver = db.ToDelivers.Find(id);
            if (toDeliver == null)
            {
                return HttpNotFound();
            }
            return View(toDeliver);
        }

        // POST: ToDelivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDeliver toDeliver = db.ToDelivers.Find(id);
            db.ToDelivers.Remove(toDeliver);
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
