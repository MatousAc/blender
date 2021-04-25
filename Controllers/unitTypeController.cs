using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using blender.Models;

namespace blender.Controllers
{
    public class unitTypeController : Controller
    {
        private blenderEntities db = new blenderEntities();

        // GET: unitType
        public ActionResult Index()
        {
            return View(db.unit_type.ToList());
        }

        // GET: unitType/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit_type unit_type = db.unit_type.Find(id);
            if (unit_type == null)
            {
                return HttpNotFound();
            }
            return View(unit_type);
        }

        // GET: unitType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: unitType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name")] unit_type unit_type)
        {
            if (ModelState.IsValid)
            {
                db.unit_type.Add(unit_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit_type);
        }

        // GET: unitType/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit_type unit_type = db.unit_type.Find(id);
            if (unit_type == null)
            {
                return HttpNotFound();
            }
            return View(unit_type);
        }

        // POST: unitType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name")] unit_type unit_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit_type);
        }

        // GET: unitType/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit_type unit_type = db.unit_type.Find(id);
            if (unit_type == null)
            {
                return HttpNotFound();
            }
            return View(unit_type);
        }

        // POST: unitType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            unit_type unit_type = db.unit_type.Find(id);
            db.unit_type.Remove(unit_type);
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
