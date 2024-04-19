using API.Authenticate.JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Authenticate.JWT.Controllers
{
    [ApiController]
    [Route("api/clients")]
        
    public class ClientController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            List<dynamic> clients = new List<dynamic>();
            clients.Add(new { nome = "Joao", cpf = "123456458911" });
            clients.Add(new { nome = "Maria", cpf = "98765432125" });
            return Ok(clients);
        }
        [HttpGet("GetWithMasterRole")]
        [Authorize(Roles = nameof(AllowedLevel.Master))]
        public IActionResult GetWithMasterRole()
        {
            List<dynamic> clients = new List<dynamic>();
            clients.Add(new { nome = "Joao", cpf = "123456458911" });
            clients.Add(new { nome = "Maria", cpf = "98765432125" });
            return Ok(clients);
        }

        [HttpGet("GetWithCommonRole")]
        [Authorize(Roles = nameof(AllowedLevel.Common))]
        public IActionResult GetWithCommonRole()
        {
            List<dynamic> clients = new List<dynamic>();
            clients.Add(new { nome = "Joao", cpf = "123456458911" });
            clients.Add(new { nome = "Maria", cpf = "98765432125" });
            return Ok(clients);
        }


    }
}
