using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PieVerse.BLL.Interfaces;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Attributes;
using PieVerse.Web.Models;
using WebGrease.Css.Extensions;

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
            IEnumerable<Pieverse> pieverses = _service.PieverseService.Get().OrderByDescending(p => p.AddingTime).ToList();
            return View(pieverses.Select(Mapper.Map<PieverseViewModel>));
        }

        [HttpGet]
        [ActionName("add")]
        public ActionResult Add()
        {
            FirstLine line = _service.FirstLineService.GetRandomFirstLine();
            IEnumerable<FirstLineViewModel> lines = _service.FirstLineService.Get().Select(Mapper.Map<FirstLineViewModel>);
            return View(new PieverseViewModel() { FirstLine = Mapper.Map<FirstLineViewModel>(line), AllLines = lines });
        }

        [HttpPost]
        [ActionName("AddPieverse")]
        public ActionResult Add(PieverseViewModel model)
        {
            var lines = _service.FirstLineService.Get().Select(Mapper.Map<FirstLineViewModel>);
            model.AllLines = lines;
            if (ModelState.IsValid)
            {
                _service.PieverseService.Add(Mapper.Map<Pieverse>(model), User.Identity.Name);
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
                _service.FirstLineService.Add(Mapper.Map<FirstLine>(model), User.Identity.Name);
                return Content("Строка успешно добавлена!");
            }
            return PartialView("_addFirstLine", model);
        }

        public ActionResult Sort(string sorting)
        {
            IEnumerable<Pieverse> pieverses = _service.PieverseService.Get().ToList();
            switch (sorting)
            {
                case "new":
                    pieverses = pieverses.OrderByDescending(p => p.AddingTime);
                    return View("feed", pieverses.Select(Mapper.Map<PieverseViewModel>));
                case "popular":
                    pieverses = pieverses.OrderByDescending(p => p.Likes.Count);
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
            _service.LikeService.DeleteLikesOf(pieverseId: id);
            _service.PieverseService.Delete(id);
            return RedirectToAction("feed");
        }

        public ActionResult Like(int id)
        {
            var newLikesCount = _service.LikeService.Like(pieverseId: id, userName: User.Identity.Name);
            return Content(newLikesCount.ToString());
        }
    }
}
