using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PieVerse.Web.Models;

namespace PieVerse.Web.Controllers
{
    public class PieverseController : Controller
    {
        public ActionResult Feed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PieverseViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }
    }
}
