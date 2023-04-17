using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.AspNetCore.Mvc;

namespace LatDBfirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversitasController : Controller
    {
        private readonly IUniversity _university;
        public UniversitasController(IUniversity university) { 
            _university = university;
        }
        [HttpGet]
        public async Task <IActionResult> GetALLUniverity()
        {
           var identity = await _university.Getall();
            return Ok(identity);
        }
    }
}
