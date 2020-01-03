using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luizalabs.Challenge.Contracts.v1.Requests;
using Luizalabs.Challenge.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luizalabs.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private UserService _userService;

        public SecurityController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody]UserAuth model)
        {
            try
            {
                var token = _userService.Authenticate(model.Username, model.Password);

                if (token == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}