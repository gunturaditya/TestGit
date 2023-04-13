using Microsoft.AspNetCore.Mvc;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversity _university;

        public UniversityController(IUniversity university)
        {
            _university = university;
        }
        public IActionResult Index()
        {
            var entity = _university.Getall();

            return View(entity);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _university.GetbyID(id);
            return View(entity);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Universities universities)
        {
            _university.insert(universities);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            return Details(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Universities universities)
        {
            _university.update(universities);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Details(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove (int id)
        {
            _university.delete(id);
            return RedirectToAction("Index");
        }
    }
}
