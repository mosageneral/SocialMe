using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Infrastructure;
using BL.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model.ApiModels;

namespace SocialMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ApiAuthController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
       
        private readonly IAuthenticateService _authService;
        public ApiAuthController(IUnitOfWork uow, IAuthenticateService authService, IOptions<TokenManagement> tokenManagement, IHostingEnvironment env)
        {
            _uow = uow;
            _authService = authService;
        }

        /// <summary>
        /// Log in user
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200"> user object and token </response>
        /// <response code="400">invalid user name or password</response>
        /// <response code="401">Unauthorized</response>
        [AllowAnonymous]
        [HttpPost, Route("LogIn")]
        public IActionResult LogIn([FromBody] ApiLoginModel request)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            var user = _authService.AuthenticateUser(request, out string token);
            if (user != null)
            {
                user.Password = null;
                return Ok(new
                {
                    user,
                    token
                });
            }
            return BadRequest("Invalid Username or Password");
        }
    }
}