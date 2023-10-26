using LibraryWebApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApp.Controllers
{
    [CustomAuthenticationFilter]
    public class HomeController : Controller
    {
        //[CustomAuthorize("Library Admin", "Library Staff", "Library Customer")]
        public ActionResult Index()
        {
            return View();
        }

        //[CustomAuthorize("Library Admin", "Library Staff", "Library Customer")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[CustomAuthorize("Library Admin", "Library Staff", "Library Customer")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Un Authorized Page!";

            return View();
        }
    }
}