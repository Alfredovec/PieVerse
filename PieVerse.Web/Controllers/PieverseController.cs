using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<string> lines = _service.FirstLineService.Get().Select(x => x.Text);
            return View(new PieverseViewModel() { FirstLine = Mapper.Map<FirstLineViewModel>(line), AllLines = lines});
        }

        [HttpPost]
        [ActionName("AddPieverse")]
        public ActionResult Add(PieverseViewModel model)
        {
            IEnumerable<string> lines = _service.FirstLineService.Get().Select(x => x.Text);
            model.AllLines = lines;
            if (ModelState.IsValid)
            {
                _service.PayverseService.Add(Mapper.Map<Pieverse>(model));
                return Content("Пирожок успешно добавлен!");
            }
            return PartialView("_addPieverse", model);
        }

        [HttpPost]
        [ActionName("AddFirstline")]
        public ActionResult Add(FirstLineViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.FirstLineService.Add(Mapper.Map<FirstLine>(model));
                return Content("Строка успешно добавлена!");
            }
            return PartialView("_addFirstLine", model);
        }

        public ActionResult Sort(string sortingField)
        {
            IEnumerable<Pieverse> pieverses = _service.PayverseService.Get().ToList();
            switch (sortingField)
            {
                case "new":
                    pieverses = pieverses.OrderBy(p => p.Id);
                    return View("feed", pieverses.Select(Mapper.Map<PieverseViewModel>));
                case "popular":
                    pieverses = pieverses.OrderBy(p => p.FirstLine.Text);
                    return View("feed", pieverses.Select(Mapper.Map<PieverseViewModel>));
            }
            return RedirectToAction("feed");
        }

        public PartialViewResult RefreshLine()
        {
            FirstLine line = _service.FirstLineService.GetRandomFirstLine();
            return PartialView("_FirstLine", new FirstLineViewModel() { Text = line.Text, Id = line.Id });
        }

        public ActionResult Delete(int id)
        {
            _service.PayverseService.Delete(id);
            return RedirectToAction("feed");
        }

        public ActionResult Like(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
