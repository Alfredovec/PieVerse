using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using PieVerse.Web.Attributes;
using PieVerse.Web.Filters;
using PieVerse.Web.Models;
using WebMatrix.WebData;

namespace PieVerse.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(model.UserName, model.Password))
                {
                    //if (returnUrl != null)
                    //    return Redirect(returnUrl);
                    return RedirectToAction("feed", "Pieverse");
                }
                ModelState.AddModelError("", "Sorry, the username or password is invalid");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model, string role = "User")
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    Roles.AddUserToRole(model.UserName, role);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("feed", "Pieverse");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Sorry, the username already exists");
                }
            }
            return View(model);
        }

        [PieverseAuthorize]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("feed", "Pieverse");
        }
    }
}
