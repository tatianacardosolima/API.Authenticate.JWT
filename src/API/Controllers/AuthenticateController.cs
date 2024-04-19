using API.Authenticate.JWT.Interfaces;
using API.Authenticate.JWT.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Authenticate.JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {       

        private readonly ILogger<AuthenticateController> _logger;
        private readonly ITokenService _tokenService;

        public AuthenticateController(ILogger<AuthenticateController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            // simula usuários
            UserList.users.Add(new Models.User ("tatiana", "123456", AllowedLevel.Master)); // 
            UserList.users.Add(new Models.User("elias", "123456", AllowedLevel.Common)); // 

            var token = _tokenService.GetToken(user);
            if (string.IsNullOrEmpty(token) ) return Unauthorized();
            else return Ok(_tokenService.GetToken(user));
        }
    }
}
