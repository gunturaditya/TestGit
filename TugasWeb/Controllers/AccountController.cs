using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.ModelVM;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployee _employee;
        private readonly MyContext _context;
        public AccountController(IAccountRepository accountRepository,MyContext myContext)
        {
            _context = myContext;
            _accountRepository = accountRepository;
        }

        public IActionResult Index()
        {
            var entity = _accountRepository.Getall();
   

            return View(entity);
          
        }
        public IActionResult Register()
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

        // POST - Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerVM)
        {
            var result = _accountRepository.Register(registerVM);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // GET - Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(VMLogin loginVM,Employees employee,Account accounts)
        {

          
            var data = _context.Employees.Where(u => u.Email == employee.Email ).SingleOrDefault();
                if (data != null)
                {

                    var isvalid = (loginVM.Email == employee.Email && loginVM.Password == accounts.Password);
                    if (isvalid)
                    {
                         if (employee.Role == 0)
                         {
                        var identity = new ClaimsIdentity(new[]
                             {
                               new Claim(ClaimTypes.Name,employee.Email) }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Email", employee.Email);

                        return RedirectToAction("Index", "Home");
                           }
                    else
                    {
                        var identity = new ClaimsIdentity(new[]
                             {
                               new Claim(ClaimTypes.Name,employee.Email) }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Email", employee.Email);

                        return RedirectToAction("Register", "Account");
                    }
                     }
                    else
                    {
                        TempData["errorMassage"] = "Invalid Password";
                    }
                }
                else
                {
                    TempData["errorMassage"] = "Username Not Found";
                    return View();
                }
            
            
            return View();
         }
            

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Account");
        }

    }
}
