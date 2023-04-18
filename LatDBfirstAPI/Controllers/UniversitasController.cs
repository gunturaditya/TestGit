using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> GetALLUniverity()
        {
            var identity = await _university.GetallAsync();
            try
            {
                if (identity == null)
                {
                    return NotFound(new
                    {
                        code = StatusCodes.Status404NotFound,
                        status = HttpStatusCode.NotFound.ToString(),
                        data = new
                        {
                            message = "Data Not Found!"
                        }
                    });

                }
                return Ok(new
                {
                    Code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = identity,
                });
            } catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }
        [HttpGet("{id}", Name = "GetALLUniverityiId")]
        public async Task<IActionResult> GetALLUniverityiId(int id)
        {
            var identity = await _university.GetbyIDAsync(id);
            try
            {
                if (identity == null)
                {
                    return NotFound(new
                    {
                        Code = StatusCodes.Status404NotFound,
                        status = HttpStatusCode.NotFound,
                        data = new

                        {
                            identity,
                            message = "data not find"
                        }

                    });
                }
                return Ok(new
                {
                    Code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new

                    {
                        identity,
                        message = "data find"
                    }

                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Insert(University university)
        {

            var identity = await _university.InsertAsync(university);

            try
            { 
                if (university != null)
                {
                    return BadRequest(new
                    {
                        Code = StatusCodes.Status401Unauthorized,
                        status = HttpStatusCode.MultiStatus,
                        data = identity
                    });
                }
                return Ok(new
                {
                    Code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new {
                        identity,
                        message = "Insert Success"
                    }

                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
           
            var identity = await _university.deleteAsync(id);
            if (identity == null)
            {
                return NotFound(new
                {
                    Code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound,
                    data = new
                    {
                        identity,
                        messege = "Delete failed"
                    }
                });

            }
            return Ok(new
            {
                Code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK,
                data = new
                {
                    identity,
                    messege = "Delete Success"
                }
            });


        }

        [HttpPut]
        public async Task<IActionResult> updtae(University university)
        {
            var identity = await _university.updateAsync(university);
            
            
                return Ok(new
                {
                    Code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK,
                    data = identity

                });
            

        }




    }
}
