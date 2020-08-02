using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using BlueModas.Infra.CrossCutting.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AutenticacaoController : ControllerBase
    {
        IServiceUsuario _service;
        public AutenticacaoController(IServiceUsuario service) => _service = service;

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] Usuario model)
        {
            var user = _service.GetByNomeSenha(model.Nome, model.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválido" });

            var token = TokenService.GenerateToken(user);
            user.Senha = "";

            return new { user, token };
        }

        [HttpGet]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => $"Funcionário";

        [HttpGet]
        [Authorize(Roles = "manager")]
        public string Manager() => $"Gerente";

    }
}
