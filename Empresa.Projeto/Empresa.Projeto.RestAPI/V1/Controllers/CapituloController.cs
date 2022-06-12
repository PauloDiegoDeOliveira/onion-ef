using Empresa.Projeto.Application.Adaptatives;
using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Capitulo")]
    [ApiController]
    public class CapituloController : ControllerBase
    {
        private readonly IApplicationCapitulo applicationCapitulo;

        public CapituloController(IApplicationCapitulo applicationCapitulo)
        {
            this.applicationCapitulo = applicationCapitulo;
        }

        /// <summary>
        /// Retorna todos os capítulos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewCapituloDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewCapituloDto> result = await applicationCapitulo.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum capítulo foi encontrado." });
        }

        /// <summary>
        /// Retorna um capítulo consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewCapituloDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewCapituloDto result = await applicationCapitulo.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum capítulo foi encontrado com o id informado." });
        }

        /// <summary>
        /// Insere um novo capítulo.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostCapituloDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await applicationCapitulo.PostAsync(post);
            return Ok(new { mensagem = "Capítulo criado com sucesso!" });
        }

        /// <summary>
        /// Altera um capítulo.
        /// </summary>
        /// <param name="put"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutCapituloDto put)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewCapituloDto result = await applicationCapitulo.PutAsync(put);
            if (result != null)
                return Ok(new { mensagem = "Capítulo atualizado com sucesso!" });

            return NotFound(new { mensagem = "Nenhum capítulo foi encontrado com o id informado." });
        }

        /// <summary>
        /// Exclui um capítulo.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma especialidade o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewCapituloDto result = await applicationCapitulo.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Capítulo removido com sucesso!" });

            return NotFound(new { mensagem = "Nenhum capítulo foi encontrado com o id informado." });
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

            ViewCapituloDto result = await applicationCapitulo.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhum capítulo foi encontrado com o id informado." });
        }

        /// <summary>
        /// Retorna detalhes de um capítulo consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detalhes")]
        [ProducesResponseType(typeof(CapituloAdaptative), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdDetalhesAdaptativeAsync(long id)
        {
            CapituloAdaptative result = await applicationCapitulo.GetByIdDetalhesAdaptativeAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum capítulo foi encontrado com o id informado." });
        }
    }
}
