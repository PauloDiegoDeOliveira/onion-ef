using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/permissoes")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        private readonly IApplicationServicePermissao applicationServicePermissao;

        public PermissaoController(IApplicationServicePermissao applicationServicePermissao)
        {
            this.applicationServicePermissao = applicationServicePermissao;
        }

        /// <summary>
        /// Retorna todas as permissões.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<ViewPermissaoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IList<ViewPermissaoDto> result = await applicationServicePermissao.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(new { mensagem = "Nenhuma permissão foi encontrada." });
        }

        /// <summary>
        /// Retorna uma permissão consultado via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewPermissaoDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewPermissaoDto result = await applicationServicePermissao.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
            }
            return Ok(result);
        }

        /// <summary>
        /// Insere uma nova permissão.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostPermissaoDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewPermissaoDto result = await applicationServicePermissao.PostAsync(post);
            return Ok(new { mensagem = "Permissão criada com sucesso!" });
        }

        /// <summary>
        /// Altera uma permissão.
        /// </summary>
        /// <param name="put"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutPermissaoDto put)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewPermissaoDto result = await applicationServicePermissao.PutAsync(put);
            if (result == null)
            {
                return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
            }
            return Ok(new { mensagem = "Permissão atualizada com sucesso!" });
        }

        /// <summary>
        /// Exclui uma permissão.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma permissão o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewPermissaoDto result = await applicationServicePermissao.DeleteAsync(id);
            if (result == null)
            {
                return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
            }
            return Ok(new { mensagem = "Permissão removida com sucesso!" });
        }

        /// <summary>
        /// Atualiza o status para 3 excluído.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("status-exluido")]
        public async Task<IActionResult> PutStatusAsync(long id)
        {
            ViewPermissaoDto consulta = await applicationServicePermissao.PutStatusAsync(id);
            if (consulta == null)
            {
                return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
            }
            return Ok(new { mensagem = "Permissão removida com sucesso!" });
        }

    }
}