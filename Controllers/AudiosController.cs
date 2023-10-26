using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryWebApp.Models;

namespace WebApplication1.Controllers
{
    public class AudiosController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: Audios
        public ActionResult Index()
        {
            var audios = db.audios.Include(a => a.checkout_records);
            return View(audios.ToList());
        }

        // GET: Audios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            audio audio = db.audios.Find(id);
            if (audio == null)
            {
                return HttpNotFound();
            }
            return View(audio);
        }

        // GET: Audios/Create
        public ActionResult Create()
        {
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            return View();
        }

        // POST: Audios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "audio_id,audio_type,audio_title,audio_author,audio_publisher,audio_genre,audio_length,last_checkout,last_return,last_transaction")] audio audio)
        {
            if (ModelState.IsValid)
            {
                db.audios.Add(audio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", audio.last_transaction);
            return View(audio);
        }

        // GET: Audios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            audio audio = db.audios.Find(id);
            if (audio == null)
            {
                return HttpNotFound();
            }
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", audio.last_transaction);
            return View(audio);
        }

        // POST: Audios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "audio_id,audio_type,audio_title,audio_author,audio_publisher,audio_genre,audio_length,last_checkout,last_return,last_transaction")] audio audio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", audio.last_transaction);
            return View(audio);
        }

        // GET: Audios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            audio audio = db.audios.Find(id);
            if (audio == null)
            {
                return HttpNotFound();
            }
            return View(audio);
        }

        // POST: Audios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            audio audio = db.audios.Find(id);
            db.audios.Remove(audio);
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
