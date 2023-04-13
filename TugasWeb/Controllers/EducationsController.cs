using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Controllers
{
    public class EducationsController : Controller
    {
        private readonly IEducations _education;
        private readonly IUniversity _university;
       
        public EducationsController(IEducations educations, IUniversity university)
        {

            _education = educations;
            _university = university;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var entity = _education.Getall();
            var universities = _university.Getall();
            var selectdata = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.Universitas_id = selectdata;

            return View(entity);
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            var entity = _education.GetbyID(id);
            var universities = _university.Getall();
            var selectdata = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.Universitas_id = selectdata;
            return View(entity);
        }

        [HttpGet]

        public IActionResult Create() {
         
            var universities = _university.Getall();
            var selectdata = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.Universitas_id = selectdata;
            return View();
        }
        [HttpPost]

        public IActionResult Create(Educations educations)
        {
            
            _education.insert(educations);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var universities = _university.Getall();
            
            var selectdata = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.Universitas_id = selectdata;
            return Details(id);
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            _education.delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var universities = _university.Getall();
            var selectdata = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.Universitas_id = selectdata;
            return Details(id);
        }

        [HttpPost] 
        public IActionResult Edit(Educations educations)
        {
            _education.update(educations);
            return RedirectToAction("Index");
        }
    }
}
