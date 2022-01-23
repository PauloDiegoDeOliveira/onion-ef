using Empresa.Projeto.Application.Dtos.Usuario;
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

        /// <summary>
        /// Retorna um usuário consultado via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var consultado = await serviceUsuario.GetByIdAsync(id);
            if (consultado == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
            }
            return Ok(consultado);
        }

        /// <summary>
        /// Insere um novo usuário.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostUsuarioDto post)
        {
            var inserido = await serviceUsuario.PostAsync(post);
            return Ok(new { mensagem = "Usuário criado com sucesso!" });
        }

        /// <summary>
        /// Altera um novo usuário.
        /// </summary>
        /// <param name="put"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutUsuarioDto put)
        {
            var atualizado = await serviceUsuario.PutAsync(put);
            if (atualizado == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
            }
            return Ok(new { mensagem = "Usuário atualizado com sucesso!" });
        }

        /// <summary>
        /// Exclui um usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um usuário o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var removido = await serviceUsuario.DeleteAsync(id);
            if (removido == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
            }
            return Ok(new { mensagem = "Usuário removido com sucesso!" });
        }
    }
}