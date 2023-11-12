using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Net;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class WaitlistController : Controller

    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: Waitlist
        public ActionResult Index()
        {
            var waitlist = db.waitlists.ToList();
            return View(waitlist);
        }

        // GET: Waitlist/Details/5
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

        // GET: Waitlist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Waitlist/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Waitlist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Waitlist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Waitlist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Waitlist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
