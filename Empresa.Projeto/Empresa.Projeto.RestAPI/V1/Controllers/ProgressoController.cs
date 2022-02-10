using Empresa.Projeto.Application.Dtos.Progresso;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Progresso")]
    [ApiController]
    public class ProgressoController : ControllerBase
    {
        private readonly IApplicationProgresso applicationProgresso;

        public ProgressoController(IApplicationProgresso applicationProgresso)
        {
            this.applicationProgresso = applicationProgresso;
        }

        /// <summary>
        /// Retorna todos os progressos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewProgressoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewProgressoDto> result = await applicationProgresso.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum progresso foi encontrado." });
        }

        /// <summary>
        /// Retorna um progresso consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewProgressoDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewProgressoDto result = await applicationProgresso.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum progresso foi encontrado com o id informado." });
        }

        /// <summary>
        /// Insere um novo progresso.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostProgressoDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await applicationProgresso.PostAsync(post);
            return Ok(new { mensagem = "Progresso criado com sucesso!" });
        }

        /// <summary>
        /// Altera um progresso.
        /// </summary>
        /// <param name="put"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutProgressoDto put)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ViewProgressoDto result = await applicationProgresso.PutAsync(put);
            if (result != null)
                return Ok(new { mensagem = "Progresso atualizado com sucesso!" });

            return NotFound(new { mensagem = "Nenhum progresso foi encontrado com o id informado." });
        }

        /// <summary>
        /// Exclui um progresso.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma especialidade o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewProgressoDto result = await applicationProgresso.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Progresso removido com sucesso!" });

            return NotFound(new { mensagem = "Nenhum progresso foi encontrado com o id informado." });
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

            ViewProgressoDto result = await applicationProgresso.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhum progresso foi encontrado com o id informado." });
        }
    }
}