using Empresa.Projeto.Application.Dtos.ClienteForm;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Enums;
using Empresa.Projeto.RestAPI.URLs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/ClienteForm")]
    [ApiController]
    public class ClienteFormController : ControllerBase
    {
        private readonly IApplicationClienteForm applicationClienteForm;

        private Caminhos[] urls;

        public ClienteFormController(IApplicationClienteForm applicationClienteForm)
        {
            this.applicationClienteForm = applicationClienteForm;
            PopulateURLs();
        }

        private void PopulateURLs()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"../../Empresa.Projeto/Empresa.Projeto.RestAPI/URLs/Diretorios.json");
            string json = System.IO.File.ReadAllText(path);
            urls = JsonConvert.DeserializeObject<Caminhos[]>(json);
        }

        /// <summary>
        /// Retorna todos os cliente.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewClienteFormDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewClienteFormDto> result = await applicationClienteForm.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum cliente foi encontrado." });
        }

        /// <summary>
        /// Retorna um cliente consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewClienteFormDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewClienteFormDto result = await applicationClienteForm.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum cliente foi encontrado com o id informado." });
        }

        /// <summary>
        /// Faz um upload de cliente em um diretório escolhido por parâmetro (Tamanho máximo 10 MB).
        /// </summary>
        /// <param name="postUploadForm"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        // 10 Megabyte
        [RequestSizeLimit(10000000)]
        [HttpPost]
        public async Task<ActionResult> PostUploadForm([FromForm] PostClienteFormDto postUploadForm, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (postUploadForm.ImagemUpload == null || postUploadForm.ImagemUpload.Length == 0)
                return BadRequest(new { mensagem = "Insira uma imagem!" });

            if ((int)diretorio > urls.Length || diretorio == 0)
                return BadRequest(new { mensagem = "Diretório não encontrado." });

            ViewClienteFormDto objeto = await applicationClienteForm.PostAsync(postUploadForm, urls[(int)diretorio - 1].diretoriosAbsolutos, urls[(int)diretorio - 1].diretoriosRelativos);

            return Ok(new { mensagem = "Upload efetuado com sucesso.", objeto.NomeArquivoOriginal, objeto.IdGuid, objeto.CaminhoRelativo });
        }

        /// <summary>
        /// Substitui um cliente em um diretório escolhido por parâmetro (Tamanho máximo 10 MB).
        /// </summary>
        /// <param name="putUploadForm"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        // 10 Megabyte
        [RequestSizeLimit(10000000)]
        [HttpPut]
        public async Task<ActionResult> PutUploadForm([FromForm] PutClienteFormDto putUploadForm, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (putUploadForm.ImagemUpload == null || putUploadForm.ImagemUpload.Length == 0)
                return BadRequest(new { mensagem = "Insira uma imagem!" });

            if ((int)diretorio > urls.Length || diretorio == 0)
                return BadRequest(new { mensagem = "Diretório não encontrado." });

            ViewClienteFormDto objeto = await applicationClienteForm.PutAsync(putUploadForm, urls[(int)diretorio - 1].diretoriosAbsolutos, urls[(int)diretorio - 1].diretoriosRelativos);

            if (objeto is null)
                return NotFound(new { mensagem = "Id de cliente não encontrado." });

            return Ok(new { mensagem = "Upload efetuado com sucesso.", objeto.NomeArquivoOriginal, objeto.IdGuid, objeto.CaminhoRelativo });
        }

        /// <summary>
        /// Exclui uma Imagem.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um cliente o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewClienteFormDto result = await applicationClienteForm.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Cliente removida com sucesso!" });

            return NotFound(new { mensagem = "Nenhum cliente foi encontrado com o id informado." });
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

            ViewClienteFormDto result = await applicationClienteForm.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhum cliente foi encontrado com o id informado." });
        }

    }
}
