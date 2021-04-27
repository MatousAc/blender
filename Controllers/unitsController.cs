using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace blender.Models
{
    public class unitsController : Controller
    {
        private blenderEntities db = new blenderEntities();

        // GET: units
        public ActionResult Index()
        {
            var units = db.units.Include(u => u.unit_system).Include(u => u.unit_type);
            return View(units.ToList());
        }

        // GET: units/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit unit = db.units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: units/Create
        public ActionResult Create()
        {
            ViewBag.system = new SelectList(db.unit_system, "name", "name");
            ViewBag.type = new SelectList(db.unit_type, "name", "name");
            return View();
        }

        // POST: units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,type,system")] unit unit)
        {
            if (ModelState.IsValid)
            {
                db.units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.system = new SelectList(db.unit_system, "name", "name", unit.system);
            ViewBag.type = new SelectList(db.unit_type, "name", "name", unit.type);
            return View(unit);
        }

        // GET: units/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit unit = db.units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.system = new SelectList(db.unit_system, "name", "name", unit.system);
            ViewBag.type = new SelectList(db.unit_type, "name", "name", unit.type);
            return View(unit);
        }

        // POST: units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name,type,system")] unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.system = new SelectList(db.unit_system, "name", "name", unit.system);
            ViewBag.type = new SelectList(db.unit_type, "name", "name", unit.type);
            return View(unit);
        }

        // GET: units/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit unit = db.units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            unit unit = db.units.Find(id);
            db.units.Remove(unit);
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
