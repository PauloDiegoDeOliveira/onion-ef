using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IApplicationServiceUsuario serviceUsuario;

        public UsuariosController(IApplicationServiceUsuario serviceUsuario)
        {
            this.serviceUsuario = serviceUsuario;
        }

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<ViewUsuarioDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IList<ViewUsuarioDto> result = await serviceUsuario.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(new { mensagem = "Nenhum usuário foi encontrado." });
        }

        /// <summary>
        /// Retorna um usuário consultado via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewUsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewUsuarioDto result = await serviceUsuario.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
            }
            return Ok(result);
        }

        /// <summary>
        /// Insere um novo usuário.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostUsuarioDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewUsuarioDto result = await serviceUsuario.PostAsync(post);
            return Ok(new { mensagem = "Usuário criado com sucesso!" });
        }

        /// <summary>
        /// Altera um usuário.
        /// </summary>
        /// <param name="put"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutUsuarioDto put)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewUsuarioDto result = await serviceUsuario.PutAsync(put);
            if (result == null)
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
            ViewUsuarioDto result = await serviceUsuario.DeleteAsync(id);
            if (result == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
            }
            return Ok(new { mensagem = "Usuário removido com sucesso!" });
        }

        /// <summary>
        /// Consultar nome.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome")]
        [ProducesResponseType(typeof(ViewUsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNomeAsync(string nome)
        {
            IList<ViewUsuarioDto> result = await serviceUsuario.GetNomeAsync(nome);
            if (result.Count == 0)
            {
                return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o nome informado." });
            }
            return Ok(result);
        }

        /// <summary>
        /// Atualiza o status para 3 excluído.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("status-exluido")]
        public async Task<IActionResult> PutStatusAsync(long id)
        {
            ViewUsuarioDto consulta = await serviceUsuario.PutStatusAsync(id);
            if (consulta == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
            }
            return Ok(new { mensagem = "Usuário removido com sucesso!" });
        }
    }
}