using Empresa.Projeto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationServiceUsuario serviceUsuario;

        public UsuarioController(IApplicationServiceUsuario serviceUsuario)
        {
            this.serviceUsuario = serviceUsuario;
        }

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var consulta = await serviceUsuario.GetAllAsync();
            if (consulta.Any())
            {
                return Ok(consulta);
            }
            return NotFound(new { mensagem = "Nenhum usuário foi encontrado." });
        }
    }
}