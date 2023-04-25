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
    [Authorize(Roles = "USER")]
    public class UniversityController : GeneralController<IUniverityRepository, University, int>
    {
        public UniversityController(IUniverityRepository repository) : base(repository) { }
    }
}
