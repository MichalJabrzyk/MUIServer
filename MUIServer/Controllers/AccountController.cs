using Microsoft.AspNetCore.Mvc;
using MUIServer.Models;
using MUIServer.Services;

namespace MUIServer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController (IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDTO userDTO)
        {
            _accountService.RegisterUser(userDTO);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO loginDTO)
        {
            string token = _accountService.GenerateJwt(loginDTO);
            return Ok(token);
        }

    }
}
