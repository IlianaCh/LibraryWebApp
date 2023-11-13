using LibraryWebApp.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new LibraryDBEntities())
                {
                    user user = context.users
                                       .Where(u => u.username == model.username && u.password == model.password)
                                       .FirstOrDefault();

                    if (user != null)
                    {
                        Session["UserName"] = user.username;
                        Session["UserId"] = user.user_id;
                        Session["Role"] = user.user_role;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(model);
                    }
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            Session["Role"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}