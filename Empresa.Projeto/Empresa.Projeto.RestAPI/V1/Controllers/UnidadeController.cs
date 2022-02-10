using Empresa.Projeto.Application.Adaptatives;
using Empresa.Projeto.Application.Dtos.Unidade;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Unidade")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IApplicationUnidade applicationUnidade;

        public UnidadeController(IApplicationUnidade applicationUnidade)
        {
            this.applicationUnidade = applicationUnidade;
        }

        /// <summary>
        /// Retorna todas as unidades.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewUnidadeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewUnidadeDto> result = await applicationUnidade.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma unidade foi encontrada." });
        }

        /// <summary>
        /// Retorna uma unidade consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewUnidadeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewUnidadeDto result = await applicationUnidade.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma unidade foi encontrada com o id informado." });
        }

        /// <summary>
        /// Insere uma nova unidade.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostUnidadeDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await applicationUnidade.PostAsync(post);
            return Ok(new { mensagem = "Unidade criada com sucesso!" });
        }

        /// <summary>
        /// Altera uma unidade.
        /// </summary>
        /// <param name="put"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutUnidadeDto put)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewUnidadeDto result = await applicationUnidade.PutAsync(put);
            if (result != null)
                return Ok(new { mensagem = "Unidade atualizada com sucesso!" });

            return NotFound(new { mensagem = "Nenhuma unidade foi encontrada com o id informado." });
        }

        /// <summary>
        /// Exclui uma unidade.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma especialidade o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewUnidadeDto result = await applicationUnidade.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Unidade removida com sucesso!" });

            return NotFound(new { mensagem = "Nenhuma unidade foi encontrada com o id informado." });
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

            ViewUnidadeDto result = await applicationUnidade.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhuma unidade foi encontrada com o id informado." });
        }

        /// <summary>
        /// Retorna detalhes de uma unidade consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detalhes")]
        [ProducesResponseType(typeof(UnidadeAdaptative), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdDetalhesAdaptativeAsync(long id)
        {
            UnidadeAdaptative result = await applicationUnidade.GetByIdDetalhesAdaptativeAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma unidade foi encontrada com o id informado." });
        }
    }
}
