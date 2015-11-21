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
    [Authorize]
    public class PieverseController : Controller
    {
        private readonly IService _service;

        public PieverseController(IService service)
        {
            _service = service;
        }

        [ActionName("feed")]
        public ActionResult GetFeed()
        {
            return View();
        }

        [HttpGet]
        [ActionName("add")]
        public ActionResult Add()
        {
            FirstLine line = _service.FirstLineService.GetRandomFirstLine();
            return View(new PieverseCreateViewModel() { FirstLine = line });
        }

        [HttpPost]
        [ActionName("add")]
        public ActionResult Add(PieverseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }

        public PartialViewResult RefreshLine()
        {
            FirstLine line = _service.FirstLineService.GetRandomFirstLine();
            return PartialView("_FirstLine", line);
        }
    }
}
