using FinalProjectS2_Guntur.Eba.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinalProjectS2_Guntur.Eba.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GeneralController<TIRepository, TEntity, TKey> : ControllerBase
    where TEntity : class
    where TIRepository : IGeneralRepository<TEntity, TKey>
    {
        protected TIRepository _repository;

        public GeneralController(TIRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<TEntity>
        [HttpGet]
       virtual public async Task<ActionResult> GetAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                message = result

            });
        }

        // GET: api/<TEntity>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(TKey id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    message = result
                });
            }
            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                message = result

            });
        }

        // POST: api/<TEntity>
    
        [HttpPost]
       virtual public async Task<ActionResult> PostAsync(TEntity entity)
        {
            var result = await _repository.InsertAsync(entity);
            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                message = result

            });
        }

        // PUT: api/<TEntity>/5
        [HttpPut("{id}")]
       virtual public async Task<ActionResult> PutAsync(TKey id, TEntity entity)
        {
            var request = id.Equals(entity.GetType().GetProperty("Id")) ||
                id.Equals(entity.GetType().GetProperty("Nik"));

            if (request)
            {
                return BadRequest(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    message = request

                });
            }

            if (!await _repository.IsExist(id))
            {
                return NotFound();
            }

            await _repository.UpdateAsync(entity);
            return NoContent();
        }
        // DELETE: api/<TEntity>/5
        [HttpDelete("{id}")]
      virtual  public async Task<ActionResult> DeleteAsync(TKey id)
        {
            if (!await _repository.IsExist(id))
            {
                return NotFound();
            }

            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity!);
            return NoContent();
        }
    }
}
