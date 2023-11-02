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
    public class feesController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: fees
        [CustomAuthorize("Library Admin", "Library Staff")]
        public ActionResult Index()
        {
            var fees = db.fees.Include(f => f.checkout_records).Include(f => f.checkout_records1).Include(f => f.checkout_records2).Include(f => f.checkout_records3).Include(f => f.user).Include(f => f.user1).Include(f => f.user2).Include(f => f.user3);
            return View(fees.ToList());
        }

        // GET: fees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // GET: fees/Create
        public ActionResult Create()
        {
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id");
            ViewBag.user_id = new SelectList(db.users, "user_id", "username");
            ViewBag.user_id = new SelectList(db.users, "user_id", "username");
            ViewBag.user_id = new SelectList(db.users, "user_id", "username");
            ViewBag.user_id = new SelectList(db.users, "user_id", "username");
            return View();
        }

        // POST: fees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fee_id,user_id,transaction_id,create_date,total_fee,remaining_fee,is_paid")] fee fee)
        {
            if (ModelState.IsValid)
            {
                db.fees.Add(fee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            return View(fee);
        }

        // GET: fees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            return View(fee);
        }

        // POST: fees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fee_id,user_id,transaction_id,create_date,total_fee,remaining_fee,is_paid")] fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.transaction_id = new SelectList(db.checkout_records, "transaction_id", "transaction_id", fee.transaction_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "username", fee.user_id);
            return View(fee);
        }

        // GET: fees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // POST: fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fee fee = db.fees.Find(id);
            db.fees.Remove(fee);
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
