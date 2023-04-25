using FinalProjectS2_Guntur.Eba.Base;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;
using FinalProjectS2_Guntur.Eba.VIewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinalProjectS2_Guntur.Eba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProfillingController : GeneralController<IProfillingRepository,Profiling, String>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public ProfillingController(IProfillingRepository repository,IEmployeeRepository employeeRepository) : 
            base(repository) { 
        _employeeRepository = employeeRepository;
        }
        [HttpGet("AvgGPA/{tahun}")]
       public async Task<ActionResult<EmployeesEducationVM>> Get(int tahun)
        {
            var identity = await _employeeRepository.GetAvarage(tahun);
            var cekData = identity.Any(x => x.Hiring.Year == tahun);
            if (cekData)
            {
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    message = identity

                });

            }
            return NotFound(new
            {
                code = StatusCodes.Status404NotFound,
                status = HttpStatusCode.NotFound,
                message = identity

            });

        }
        [HttpGet("TotalByMajor")]
        public async Task<ActionResult<EmployeeCountVM>> GetCount()
        {
            var identity = await _employeeRepository.GetEmployeesCount();

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                message = identity

            });
        }
        [HttpGet("WorkPeriode")]
        public async Task<ActionResult<EmployeeDaysWork>> GetWork()
        {
            var identity = await _employeeRepository.getEmployeeWorkDays();

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                message = identity

            });
        }
    }
}
