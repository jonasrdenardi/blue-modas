using BlueModas.Domain.Entities;
using BlueModas.Infra.CrossCutting.Authentication;
using BlueModas.Infra.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválido" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
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
