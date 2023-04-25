using FinalProjectS2_Guntur.Eba.Base;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectS2_Guntur.Eba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EducationsController : GeneralController<IEducationsRepository, Education, int>
    {
        public EducationsController(IEducationsRepository repository) : base(repository) { }


         [Authorize(Roles = "USER")]

        public override Task<ActionResult> GetAsync()
        {
            return base.GetAsync();
        }
         [Authorize(Roles = "ADMIN")]
        public override Task<ActionResult> PostAsync(Education education)
        {
            return base.PostAsync(education);
        }
         [Authorize(Roles = "ADMIN")]
        public override Task<ActionResult> DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
         [Authorize(Roles = "ADMIN")]
        public override Task<ActionResult> PutAsync(int id, Education entity)
        {
            return base.PutAsync(id, entity);
        }
    }
}
