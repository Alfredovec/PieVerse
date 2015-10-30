using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PieVerse.BLL.Interfaces;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Models;

namespace PieVerse.Web.Controllers
{
    public class PieverseController : Controller
    {
        private readonly IService _service;

        public PieverseController(IService service)
        {
            _service = service;
        }

        public ActionResult Feed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            FirstLine line = _service.FirstLineService.GetRandomFirstLine();
            return View(new PieverseCreateViewModel() { FirstLine = line });
        }

        [HttpPost]
        public ActionResult Add(PieverseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }
    }
}
