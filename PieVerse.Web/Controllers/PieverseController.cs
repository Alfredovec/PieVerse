using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PieVerse.BLL.Interfaces;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Attributes;
using PieVerse.Web.Models;

namespace PieVerse.Web.Controllers
{
    [PieverseAuthorize]
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
            IEnumerable<Pieverse> pieverses = _service.PayverseService.Get().ToList();
            return View(pieverses.Select(Mapper.Map<PieverseViewModel>));
        }

        [HttpGet]
        [ActionName("add")]
        public ActionResult Add()
        {
            FirstLine line = _service.FirstLineService.GetRandomFirstLine();
            return View(new PieverseViewModel() { FirstLine = Mapper.Map<FirstLineViewModel>(line) });
        }

        [HttpPost]
        [ActionName("AddPieverse")]
        public ActionResult Add(PieverseViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.PayverseService.Add(Mapper.Map<Pieverse>(model));
                return RedirectToAction("feed");
            }
            return View("_addPieverse", model);
        }

        [ActionName("AddFirstline")]
        public ActionResult Add(FirstLineViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.FirstLineService.Add(Mapper.Map<FirstLine>(model));
                return RedirectToAction("feed");
            }
            return View("_addFirstLine", model);
        }

        public PartialViewResult Sort()
        {
            // TODO @Rud 
            return null;
        }

        public PartialViewResult RefreshLine()
        {
            FirstLine line = _service.FirstLineService.GetRandomFirstLine();
            return PartialView("_FirstLine", new FirstLineViewModel() { Body = line.Body, Id = line.Id });
        }
    }
}
