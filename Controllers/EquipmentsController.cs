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
    public class EquipmentsController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: Equipments
        public ActionResult Index()
        {
            var equipments = db.equipments.Include(e => e.checkout_records1).Include(e => e.checkout_records2).Include(e => e.checkout_records3).Include(e => e.checkout_records4);
            return View(equipments.ToList());
        }

        // GET: Equipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipment equipment = db.equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "equip_id,equip_type,equip_title,equip_director,equip_genre,equip_length,last_checkout,last_return,last_transaction")] equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipment equipment = db.equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "equip_id,equip_type,equip_title,equip_director,equip_genre,equip_length,last_checkout,last_return,last_transaction")] equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            ViewBag.last_transaction = new SelectList(db.checkout_records, "transaction_id", "transaction_id", equipment.last_transaction);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipment equipment = db.equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            equipment equipment = db.equipments.Find(id);
            db.equipments.Remove(equipment);
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
