using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using PieVerse.BLL.Interfaces;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Attributes;
using PieVerse.Web.Models;
using WebMatrix.WebData;

namespace PieVerse.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService _service;

        public AccountController(IService service)
        {
            _service = service;
        }

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
                ModelState.AddModelError("", "Неправильный логин/пароль.");
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
                    _service.AuthorService.CreateAuthor(Mapper.Map<Author>(model));
                    return RedirectToAction("feed", "Pieverse");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Извините, этот ник уже занят.");
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
