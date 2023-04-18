using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LatDBfirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IEducations _educations;

        public EducationsController(IEducations educations)
        {
            _educations = educations;
        }

        [HttpGet]
        public  async Task <IActionResult> GetAll()
        {
            var identity = await _educations.GetallAsync();
            return Ok(identity);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Getbyid(int id) {
            var identity = await _educations.GetbyIDAsync(id);
            return Ok(identity);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Education education)
        {
            var identity = await _educations.InsertAsync(education);
            return Ok(identity);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Education education)
        {
            var identity = await _educations.updateAsync(education);
            return Ok(identity);
        }
        [HttpDelete]

        public async Task<IActionResult> Delete(int id )
        {
            var identity = await _educations.deleteAsync(id);
            return Ok(identity);
        }
    }
}
