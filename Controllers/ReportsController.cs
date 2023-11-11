using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    public class ReportsController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StartDate,EndDate,ReportType")] Report report)
        {
            if (ModelState.IsValid)
            {
                if (report.ReportType == ReportTypes.MoviesPurchased)
                {
                    return RedirectToAction("MoviesPurchased",new { startDate = report.StartDate, endDate = report.EndDate });
                }
                if (report.ReportType == ReportTypes.BooksPurchased)
                {
                    return RedirectToAction("BooksPurchased", new { startDate = report.StartDate, endDate = report.EndDate });
                }
                if (report.ReportType == ReportTypes.FeesAccumulated)
                {
                    return RedirectToAction("FeesAccumulated", new { startDate = report.StartDate, endDate = report.EndDate });
                }
            }

            return View(report);
        }

        public ActionResult MoviesPurchased(DateTime? startDate, DateTime? endDate)
        {
            var objects = db.objects.Where(x => x.objects_type.type_desc == "Movie");
            if (startDate != null)
            {
                objects = objects.Where(x => x.checkout_records.Any(y => y.create_date >= startDate));
            }
            if(endDate != null)
            {
                objects = objects.Where(x => x.checkout_records.Any(y => y.create_date <= endDate));
            }
            return View(objects.ToList());
        }

        public ActionResult BooksPurchased(DateTime? startDate, DateTime? endDate)
        {
            var objects = db.objects.Where(x => x.objects_type.type_desc == "Book");
            if (startDate != null)
            {
                objects = objects.Where(x => x.checkout_records.Any(y => y.create_date >= startDate));
            }
            if (endDate != null)
            {
                objects = objects.Where(x => x.checkout_records.Any(y => y.create_date <= endDate));
            }
            return View(objects.ToList());
        }

        public ActionResult FeesAccumulated(DateTime? startDate, DateTime? endDate)
        {
            var fees = db.fees.Where(x => x.total_fee > 0);
            if (startDate != null)
            {
                fees = fees.Where(x => x.create_date >= startDate);
            }
            if (endDate != null)
            {
                fees = fees.Where(x => x.create_date <= endDate);
            }
            return View(fees.ToList());
        }
    }
}