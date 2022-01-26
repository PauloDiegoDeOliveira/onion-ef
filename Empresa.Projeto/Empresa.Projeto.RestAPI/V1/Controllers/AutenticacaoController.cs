using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IApplicationServiceUsuario serviceUsuario;

        public AutenticacaoController(IApplicationServiceUsuario serviceUsuario)
        {
            this.serviceUsuario = serviceUsuario;
        }

        /// <summary>
        /// Autentica um usuário.
        /// </summary>
        /// <param name="viewPreAutenticacao"></param>
        /// <returns></returns>
        [HttpPost("entrar")]
        [ProducesResponseType(typeof(ViewAposAutenticacaoDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AutenticacaoAsync([FromBody] ViewPreAutenticacaoDto viewPreAutenticacao)
        {
            var consultado = await serviceUsuario.AutenticacaoAsync(viewPreAutenticacao);
            if (consultado != null)
            {
                return Ok(consultado);
            }
            return Unauthorized(new { mensagem = "Usuário e/ou senha inválidos" });
        }
    }
}