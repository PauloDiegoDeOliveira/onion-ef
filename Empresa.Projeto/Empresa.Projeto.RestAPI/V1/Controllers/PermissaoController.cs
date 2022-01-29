using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [ProducesResponseType(typeof(IEnumerable<ViewPermissaoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewPermissaoDto> result = await applicationServicePermissao.GetAllAsync();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound(new { mensagem = "Nenhuma permissão foi encontrada." });
        }

        /// <summary>
        /// Retorna uma permissão consultado via id.
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
        /// Altera o status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("status")]
        public async Task<IActionResult> PutStatusAsync(long id, Status status)
        {
            if (status == 0)
            {
                return BadRequest(new { mensagem = "Nenhum status selecionado!" });
            }

            ViewPermissaoDto consulta = await applicationServicePermissao.PutStatusAsync(id, status);
            if (consulta == null)
            {
                return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
            }
            return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });
        }

        /// <summary>
        /// Atualização parcial com HTTP PATCH.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patch"></param>
        /// <remarks>Modelo: [ { "op": "replace", "path": "/titulo", "value": "Teste path 1" } ]</remarks>
        [HttpPatch("{id:long}")]
        public async Task<ActionResult> PatchAsync(long id, [FromBody] JsonPatchDocument<PutPermissaoDto> patch)
        {
            if (patch == null)
            {
                return BadRequest(new { mensagem = "O patch não pode ser nulo." });
            }

            EntityDtoStruct<Permissao, PutPermissaoDto> objetoPermissao = await applicationServicePermissao.GetByIdReturnPutAsync(id);
            if (objetoPermissao.Equals(default(EntityDtoStruct<Permissao, PutPermissaoDto>)))
            {
                return BadRequest(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
            }

            patch.ApplyTo(objetoPermissao.Dto, ModelState);
            var isValid = TryValidateModel(objetoPermissao.Dto);
            if (!isValid)
            {
                return BadRequest(new { mensagem = "Ação ou campo inválido." });
            }

            await applicationServicePermissao.SaveChangesAsync(objetoPermissao);

            return Ok(new
            {
                mensagem = "Permissão atualizada com sucesso!"
            });
        }

        /// <summary>
        /// Retorna detalhes de uma permissão consultado via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detalhes")]
        [ProducesResponseType(typeof(ViewPermissaoUsuarioDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdDetalhesAsync(long id)
        {
            ViewPermissaoUsuarioDto result = await applicationServicePermissao.GetByIdDetalhesAsync(id);
            if (result == null)
            {
                return NotFound(new { mensagem = "Nenhuma permissão foi encontrado com o id informado." });
            }
            return Ok(result);
        }
    }
}