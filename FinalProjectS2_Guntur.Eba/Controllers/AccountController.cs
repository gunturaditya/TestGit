using Azure.Core;
using FinalProjectS2_Guntur.Eba.Base;
using FinalProjectS2_Guntur.Eba.Contexts;
using FinalProjectS2_Guntur.Eba.Handler;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;
using FinalProjectS2_Guntur.Eba.VIewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;

namespace FinalProjectS2_Guntur.Eba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AccountController : GeneralController<IAccountRepository, Account, string>
    {

        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITokenService _tokenService;
        public AccountController(
       
            IAccountRepository repository,
            IAccountRoleRepository accountRoleRepository,
            ITokenService tokenService,
            IEmployeeRepository employeeRepository) : base(repository)
        {
            _tokenService = tokenService;
            _accountRoleRepository = accountRoleRepository;
            _employeeRepository = employeeRepository;
        }

      
        [HttpPost("Auth")]
       [AllowAnonymous]
        public async Task<ActionResult<Account>> LoginAsync(LoginVm loginVM)
        {
            try
            {
                var result = await _repository.LoginAsync(loginVM);
                if (!result)
                {
                    return NotFound(new
                    {
                        code = StatusCodes.Status404NotFound,
                        status = HttpStatusCode.NotFound.ToString(),
                        message = result

                    });
                }

                var userdata = await _employeeRepository.GetUserDataByEmailAsync(loginVM.Email);
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userdata.Email),
                new Claim(ClaimTypes.Name, userdata.Email),
                new Claim(ClaimTypes.NameIdentifier, userdata.FullName),
                new Claim("NIK", userdata.Nik)
            };

                var getRoles = await _accountRoleRepository.GetRolesByNikAsync(userdata.Nik);

                foreach (var item in getRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                var accessToken = _tokenService.GenerateAccessToken(claims);
                //var refreshToken = _tokenService.GenerateRefreshToken();

                //await _repository.UpdateToken(userdata.Email, refreshToken, DateTime.Now.AddDays(1)); // Token will expired in a day

                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    message = accessToken

                });
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("Register")]
       [AllowAnonymous]
        public async Task<ActionResult<Account>> RegisterAsync(RegisterVM registerVM)
        {
            try
            {
               await _repository.RegisterAsync(registerVM);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    message = "Register Success"

                });
            }
            catch
            {
                return BadRequest(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    message = "Register Failed"

                });
            }
        }
    }
}
