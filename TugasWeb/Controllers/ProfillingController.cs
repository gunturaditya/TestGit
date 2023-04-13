using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Controllers
{
    public class ProfillingController : Controller
    {
        private readonly IProfiling _profilling;
        private readonly IEducations _education;
        public ProfillingController(IProfiling general, IEducations educations)
        {

            _profilling = general;
            _education = educations;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var entity = _profilling.Getall();
            var educations = _education.Getall();
            var selectdata = educations.Select(p => new SelectListItem()
            {
                Text = p.Major,
                Value = p.Id.ToString()
            });
            ViewBag.Education_ID = selectdata;
            return View(entity);
        }

        [HttpGet]

        public IActionResult Details(string id)
        {
            var entity = _profilling.GetbyID(id);
            return View(entity);
        }

        [HttpGet]

        public IActionResult Create()
        {

            var educations = _education.Getall();

            var selectdata = educations.Select(p => new SelectListItem()
            {
                Text = p.Major,
                Value = p.Id.ToString()
            }) ;
            ViewBag.Education_ID = selectdata;
            return View();
        }
        [HttpPost]

        public IActionResult Create(Profilings profilings)
        {
            _profilling.insert(profilings);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {

            var educations = _education.Getall();

            var selectdata = educations.Select(p => new SelectListItem()
            {
                Text = p.Major,
                Value = p.Id.ToString()
            });
            ViewBag.Education_ID = selectdata;
            return Details(id);
        }
        [HttpPost]
        public IActionResult Remove(string id)
        {
            _profilling.delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {

            var educations = _education.Getall();

            var selectdata = educations.Select(p => new SelectListItem()
            {
                Text = p.Major,
                Value = p.Id.ToString()
            });
            ViewBag.Education_ID = selectdata;
            return Details(id);
        }

        [HttpPost]
        public IActionResult Edit(Profilings profilings)
        {
            _profilling.update(profilings);
            return RedirectToAction("Index");
        }
    }
}
