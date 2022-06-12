using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationUsuario applicationUsuario;

        public UsuarioController(IApplicationUsuario applicationUsuario)
        {
            this.applicationUsuario = applicationUsuario;
        }

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewUsuarioDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewUsuarioDto> result = await applicationUsuario.GetAllAsync();
            if (result.Any())
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum usuário foi encontrado." });
        }

        /// <summary>
        /// Retorna um usuário consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewUsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewUsuarioDto result = await applicationUsuario.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
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

            await applicationUsuario.PostAsync(post);
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

            ViewUsuarioDto result = await applicationUsuario.PutAsync(put);
            if (result != null)
                return Ok(new { mensagem = "Usuário atualizado com sucesso!" });

            return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
        }

        /// <summary>
        /// Exclui um usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um usuário o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewUsuarioDto result = await applicationUsuario.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Usuário removido com sucesso!" });

            return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
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
            IList<ViewUsuarioDto> result = await applicationUsuario.GetNomeAsync(nome);
            if (result.Count != 0)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o nome informado." });
        }

        /// <summary>
        /// Altera o status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("status")]
        public async Task<IActionResult> PutStatusAsync(long id, Status status)
        {
            if (status == 0)
                return BadRequest(new { mensagem = "Nenhum status selecionado!" });

            ViewUsuarioDto result = await applicationUsuario.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
        }

        /// <summary>
        /// Retorna detalhes de um usuário consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detalhes")]
        [ProducesResponseType(typeof(ViewUsuarioPermissaoDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdDetalhesAsync(long id)
        {
            ViewUsuarioPermissaoDto result = await applicationUsuario.GetByIdDetalhesAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o id informado." });
        }
    }
}