using Empresa.Projeto.Application.Dtos.Especialidade;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Especialidade")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IApplicationEspecialidade applicationEspecialidade;

        public EspecialidadeController(IApplicationEspecialidade applicationEspecialidade)
        {
            this.applicationEspecialidade = applicationEspecialidade;
        }

        /// <summary>
        /// Retorna todas as especialidades.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewEspecialidadeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewEspecialidadeDto> result = await applicationEspecialidade.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma especialidade foi encontrada." });
        }

        /// <summary>
        /// Retorna uma especialidade consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewEspecialidadeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewEspecialidadeDto result = await applicationEspecialidade.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma especialidade foi encontrada com o id informado." });
        }

        /// <summary>
        /// Insere uma nova especialidade.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostEspecialidadeDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await applicationEspecialidade.PostAsync(post);
            return Ok(new { mensagem = "Especialidade criada com sucesso!" });
        }

        /// <summary>
        /// Altera uma especialidade.
        /// </summary>
        /// <param name="put"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutEspecialidadeDto put)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewEspecialidadeDto result = await applicationEspecialidade.PutAsync(put);
            if (result != null)
                return Ok(new { mensagem = "Especialidade atualizada com sucesso!" });

            return NotFound(new { mensagem = "Nenhuma especialidade foi encontrada com o id informado." });
        }

        /// <summary>
        /// Exclui uma especialidade.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma especialidade o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewEspecialidadeDto result = await applicationEspecialidade.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Especialidade removida com sucesso!" });

            return NotFound(new { mensagem = "Nenhuma especialidade foi encontrada com o id informado." });
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

            ViewEspecialidadeDto result = await applicationEspecialidade.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhuma especialidade foi encontrada com o id informado." });
        }
    }
}
