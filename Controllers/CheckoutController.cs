using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryWebApp.Infrastructure;
using LibraryWebApp.Models;

namespace WebApplication1.Controllers
{
    [CustomAuthenticationFilter]
    public class CheckoutController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        [CustomAuthorize("Library Admin", "Library Staff")]
        // GET: Checkout
        public ActionResult Index()
        {
            var checkout_records = db.checkout_records.Include(c => c.objects).Include(c => c.user);
            return View(checkout_records.ToList());
        }

        // GET: Checkout/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkout_records checkout_records = db.checkout_records.Find(id);
            if (checkout_records == null)
            {
                return HttpNotFound();
            }
            return View(checkout_records);
        }

        // GET: Checkout/Create
        public ActionResult Create()
        {
            ViewBag.object_id = new SelectList(db.objects, "object_id", "object_title");
            /*ViewBag.object_id = new SelectList(db.audios, "audio_id", "audio_type");
            ViewBag.object_id = new SelectList(db.books, "book_id", "book_type");
            ViewBag.object_id = new SelectList(db.movies, "movie_id", "movie_type");
            ViewBag.object_id = new SelectList(db.equipments, "equip_id", "equip_type");*/
            ViewBag.user_id = new SelectList(db.users, "user_id", "username");
            return View();
        }

        // POST: Checkout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transaction_id,user_id,object_id,create_date,return_date,due_date,is_late")] checkout_records checkout_records)
        {
            if (ModelState.IsValid)
            {
                db.checkout_records.Add(checkout_records);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.object_id = new SelectList(db.audios, "audio_id", "audio_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.books, "book_id", "book_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.movies, "movie_id", "movie_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.equipments, "equip_id", "equip_type", checkout_records.object_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", checkout_records.user_id);
            return View(checkout_records);
        }

        // GET: Checkout/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkout_records checkout_records = db.checkout_records.Find(id);
            if (checkout_records == null)
            {
                return HttpNotFound();
            }
            ViewBag.object_id = new SelectList(db.audios, "audio_id", "audio_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.books, "book_id", "book_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.movies, "movie_id", "movie_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.equipments, "equip_id", "equip_type", checkout_records.object_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", checkout_records.user_id);
            return View(checkout_records);
        }

        // POST: Checkout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transaction_id,user_id,object_id,create_date,return_date,due_date,is_late")] checkout_records checkout_records)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkout_records).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.object_id = new SelectList(db.audios, "audio_id", "audio_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.books, "book_id", "book_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.movies, "movie_id", "movie_type", checkout_records.object_id);
            ViewBag.object_id = new SelectList(db.equipments, "equip_id", "equip_type", checkout_records.object_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", checkout_records.user_id);
            return View(checkout_records);
        }

        // GET: Checkout/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            checkout_records checkout_records = db.checkout_records.Find(id);
            if (checkout_records == null)
            {
                return HttpNotFound();
            }
            return View(checkout_records);
        }

        // POST: Checkout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            checkout_records checkout_records = db.checkout_records.Find(id);
            db.checkout_records.Remove(checkout_records);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Un Authorized Page!";

            return View();
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
