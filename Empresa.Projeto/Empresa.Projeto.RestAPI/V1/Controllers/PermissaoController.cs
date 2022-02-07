using Empresa.Projeto.Application.Dtos.Paginacao;
using Empresa.Projeto.Application.Dtos.Permissao;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Application.Structs;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Permissoes")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        private readonly IApplicationPermissao applicationPermissao;

        public PermissaoController(IApplicationPermissao applicationPermissao)
        {
            this.applicationPermissao = applicationPermissao;
        }

        /// <summary>
        /// Retorna todas as permissões.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewPermissaoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewPermissaoDto> result = await applicationPermissao.GetAllAsync();
            if (result != null)
                return Ok(result);

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
            ViewPermissaoDto result = await applicationPermissao.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
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

            await applicationPermissao.PostAsync(post);
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

            ViewPermissaoDto result = await applicationPermissao.PutAsync(put);
            if (result != null)
                return Ok(new { mensagem = "Permissão atualizada com sucesso!" });

            return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
        }

        /// <summary>
        /// Exclui uma permissão.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma permissão o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewPermissaoDto result = await applicationPermissao.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Permissão removida com sucesso!" });

            return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
        }

        /// <summary>
        /// Retorna uma permissão com detalhes consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detalhes/{id:long}")]
        [ProducesResponseType(typeof(ViewPermissaoDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetalhesByIdAsync(long id)
        {
            ViewPermissaoUsuarioDto result = await applicationPermissao.GetByIdDetalhesAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
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

            ViewPermissaoDto result = await applicationPermissao.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });
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
                return BadRequest(new { mensagem = "O patch não pode ser nulo." });

            EntityDtoStruct<Permissao, PutPermissaoDto> objetoPermissao = await applicationPermissao.GetByIdReturnStructDtoAsync(id);
            if (objetoPermissao.Equals(default(EntityDtoStruct<Permissao, PutPermissaoDto>)))
                return BadRequest(new { mensagem = "Nenhuma permissão foi encontrada com o id informado." });

            patch.ApplyTo(objetoPermissao.Dto, ModelState);
            var isValid = TryValidateModel(objetoPermissao.Dto);
            if (!isValid)
                return BadRequest(new { mensagem = "Ação ou campo inválido." });

            await applicationPermissao.SaveChangesAsync(objetoPermissao);

            return Ok(new { mensagem = "Permissão atualizada com sucesso!" });
        }

        /// <summary>
        /// Retorna todas as permissões dividindo-as por páginas.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="resultSize"></param>
        /// <returns></returns>
        [HttpGet("{pageNumber:int}/{resultSize:int}")]
        [ProducesResponseType(typeof(IEnumerable<ViewPermissaoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaginationAsync(int pageNumber, int resultSize)
        {
            if (pageNumber <= 0)
                return NotFound(new { mensagem = "Página não existente" });
            else if (resultSize <= 0)
                return NotFound(new { mensagem = "O tamanho de resultados exibidos não pode ser menor ou igual a 0" });

            PermissaoPagination result = await applicationPermissao.GetPaginationAsync(pageNumber, resultSize);

            if (result.Permissoes.Count <= 0)
                return NotFound(new { mensagem = "Nenhuma permissão foi encontrada." });

            return Ok(result);
        }
    }
}