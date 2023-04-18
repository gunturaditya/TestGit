using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace LatDBfirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee) {
            _employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> getall()
        {
            var identity = await _employee.GetallAsync();

            return Ok(identity);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> getdatabyid(string id)
        {
            var identity = await _employee.GetbyIDAsync(id);
            return Ok(identity);
        }

        [HttpGet("{name}",Name = "GetByUniversitas")]

        public async Task<IActionResult> GetByUniversitas(String name)
        {
            var id = 1;
            var getEmployee = await _employee.GetDataByRole(name,id);
            return Ok(getEmployee);
        }

        [HttpDelete]
        public async Task<IActionResult> removeEmployee(string id)
        {
            var identity = await _employee.deleteAsync(id);
            
            return Ok(identity);
        }
        [HttpPost]
        public async Task<IActionResult> InserEmployee(Employee employee)
        {
            var identity = await _employee.InsertAsync(employee);

            return Ok(identity);
        }


    }
}
