using FinalProjectS2_Guntur.Eba.Base;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;
using FinalProjectS2_Guntur.Eba.VIewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectS2_Guntur.Eba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class EmployeeController : GeneralController<IEmployeeRepository, Employee, string>
    {
       
        public EmployeeController(IEmployeeRepository repository) : base(repository) { }
        [HttpGet("Master")]
        public async Task<ActionResult<EmployeesEducationVM>> getData()
        {
            var identity = await _repository.GetEmployeeEducation();
            return Ok(identity);
        }
    }

    

}
