using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {

            _employee = employee;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var entity = _employee.Getall();
            return View(entity);
        }

        [HttpGet]

        public IActionResult Details(string id)
        {
            var entity = _employee.GetbyID(id);
            return View(entity);
        }

        [HttpGet]

        public IActionResult Create()
        {
            var gender = new List<SelectListItem>(){
            new SelectListItem{
                Text = "Male",
                Value = "0",
            },
            new SelectListItem{
                Text = "Female",
                Value = "1",
        }};

            ViewBag.Gender = gender;


            return View();
        }
        [HttpPost]

        public IActionResult Create(Employees employees)
        {
            _employee.insert(employees);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {

            return Details(id);
        }
        [HttpPost]
        public IActionResult Remove(string id)
        {
            _employee.delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {

            return Details(id);
        }

        [HttpPost]
        public IActionResult Edit(Employees employees)
        {
            _employee.update(employees);
            return RedirectToAction("Index");
        }
    }
}
