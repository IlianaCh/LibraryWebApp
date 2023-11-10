using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryWebApp.Models;

namespace LibraryWebApp.Controllers
{
    public class objectsController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: objects
        public ActionResult Index()
        {
            var objects = db.objects
                .Include(o => o.objects_type);
            return View(objects.ToList());
        }

        // GET: objects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objects objects = db.objects.Find(id);
            if (objects == null)
            {
                return HttpNotFound();
            }
            return View(objects);
        }

        // GET: objects/Create
        public ActionResult Create()
        {
            ViewBag.object_type = new SelectList(db.objects_type, "type_id", "type_desc");
            return View();
        }

        // POST: objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "object_id,object_type,object_title,object_author,object_medium,object_genre,object_length")] objects objects)
        {
            if (ModelState.IsValid)
            {
                db.objects.Add(objects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.object_type = new SelectList(db.objects_type, "type_id", "type_desc", objects.object_type);
            return View(objects);
        }

        // GET: objects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objects objects = db.objects.Find(id);
            if (objects == null)
            {
                return HttpNotFound();
            }
            ViewBag.object_type = new SelectList(db.objects_type, "type_id", "type_desc", objects.object_type);
            return View(objects);
        }

        // POST: objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "object_id,object_type,object_title,object_author,object_medium,object_genre,object_length")] objects objects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.object_type = new SelectList(db.objects_type, "type_id", "type_desc", objects.object_type);
            return View(objects);
        }

        // GET: objects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objects objects = db.objects.Find(id);
            if (objects == null)
            {
                return HttpNotFound();
            }
            return View(objects);
        }

        // POST: objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            objects objects = db.objects.Find(id);
            db.objects.Remove(objects);
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
