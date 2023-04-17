using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.ModelV;
using LatDBfirstAPI.Repotitory.Contract;
using LatDBfirstAPI.Repotitory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LatDBfirstAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
       
      
        private readonly IEmployee _employee;
        private readonly ILogger<EmployeeController> _logger;
        
        public EmployeeController(IEmployee employee, ILogger<EmployeeController> logger)
        {
            _employee = employee;
            _logger = logger;
          
        }

        [HttpGet]
        public async Task<ActionResult> getEmployee()
        {
            var employes = await _employee.Getall();
            return Ok(employes);
        }
        [HttpGet("{name}",Name = "getdata")]

        public async Task<IActionResult> getdata(String name)
        {
            try
            {
                var id = 1;
                var identity = await _employee.GetDataByRole(name, id);
                if (identity == null)
                {
                    _logger.LogError($"{name} Universitas not be found in Database");
                    return NotFound();
                }
                return Ok(identity);
            }catch(Exception e) {
                _logger.LogError($"Something wwnt wrong Inside getdata action : {e.Message} ");
                return StatusCode(500,"Internal Error");
            }

        }
        [HttpGet("GetEmployeeById")]
        public async Task <IActionResult> GetEmployeeById(string id)
        {
            try
            {
                
                var identity = await _employee.GetbyID(id);
                if (identity == null)
                {
                    _logger.LogError($"{id} Universitas not be found in Database");
                    return NotFound();
                }
                return Ok(identity);
            }catch(Exception ex)
            {
                _logger.LogError($"Something wwnt wrong Inside getdata action : {ex.Message} ");
                return StatusCode(500, "Internal Error");
            }
      
           //return Ok(await _myContext.Universities.ToListAsync());
        }
        [HttpPost("removeEmployee")]
        public  async Task<IActionResult> removeEmployee(string id)
        {
            var identity = _employee.deleteAsync(id);

            return Ok(identity);
        }

        [HttpPost("addEmployee")]
        public async Task<IActionResult> addEmployee(Employee employee)
        {
            var identity = _employee.insertAsync(employee);

            return Ok(identity);
        }

   
    }
}
