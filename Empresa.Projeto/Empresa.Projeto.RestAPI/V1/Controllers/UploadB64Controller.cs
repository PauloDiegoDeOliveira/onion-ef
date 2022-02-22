using Empresa.Projeto.Application.Dtos.UploadB64;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Enums;
using Empresa.Projeto.RestAPI.URLs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Empresa.Projeto.Application.Dtos.Conversor_B64;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/UploadBase64")]
    [ApiController]
    public class UploadB64Controller : ControllerBase
    {
        private readonly IApplicationUploadB64 applicationUploadB64;

        private Caminhos[] urls;

        public UploadB64Controller(IApplicationUploadB64 applicationUploadB64)
        {
            this.applicationUploadB64 = applicationUploadB64;
            PopulateURLs();
        }

        private void PopulateURLs()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"../../Empresa.Projeto/Empresa.Projeto.RestAPI/URLs/Diretorios.json");
            string json = System.IO.File.ReadAllText(path);
            urls = JsonConvert.DeserializeObject<Caminhos[]>(json);
        }

        /// <summary>
        /// Retorna todas as imagens.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewUploadB64Dto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewUploadB64Dto> result = await applicationUploadB64.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma imagem foi encontrada." });
        }

        /// <summary>
        /// Retorna uma imagem consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewUploadB64Dto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewUploadB64Dto result = await applicationUploadB64.GetByIdAsync(id);

            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhuma imagem foi encontrada com o id informado." });
        }

        /// <summary>
        /// Faz um upload de imagem em um diretório escolhido por parâmetro.
        /// </summary>
        /// <param name="postUploadB64"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostUploadB64(PostUploadB64Dto postUploadB64, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (postUploadB64.ImagemEmBase64 == null || !IsBase64String(postUploadB64.ImagemEmBase64))
                return BadRequest(new { mensagem = "Insira uma imagem!" });

            if ((int)diretorio > urls.Length || diretorio == 0)
                return BadRequest(new { mensagem = "Diretório não encontrado." });

            ViewUploadB64Dto objeto = await applicationUploadB64.PostAsync(postUploadB64, urls[(int)diretorio - 1].diretoriosAbsolutos, urls[(int)diretorio - 1].diretoriosRelativos);

            return Ok(new { mensagem = "Upload efetuado com sucesso.", objeto.IdGuid, objeto.CaminhoRelativo });
        }

        /// <summary>
        /// Substitui uma imagem em um diretório escolhido por parâmetro.
        /// </summary>
        /// <param name="putUploadB64"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutUpload(PutUploadB64Dto putUploadB64, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (putUploadB64.ImagemEmBase64 == null || !IsBase64String(putUploadB64.ImagemEmBase64))
                return BadRequest(new { mensagem = "Insira uma imagem!" });

            if ((int)diretorio > urls.Length || diretorio == 0)
                return BadRequest(new { mensagem = "Diretório não encontrado." });

            ViewUploadB64Dto objeto = await applicationUploadB64.PutAsync(putUploadB64, urls[(int)diretorio - 1].diretoriosAbsolutos, urls[(int)diretorio - 1].diretoriosRelativos);

            if (objeto is null)
                return NotFound(new { mensagem = "Id de imagem não encontrado." });

            return Ok(new { mensagem = "Upload efetuado com sucesso.", objeto.IdGuid, objeto.CaminhoRelativo });
        }

        /// <summary>
        /// Exclui uma Imagem.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma imagem o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewUploadB64Dto result = await applicationUploadB64.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Imagem removida com sucesso!" });

            return NotFound(new { mensagem = "Nenhuma Imagem foi encontrada com o id informado." });
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

            ViewUploadB64Dto result = await applicationUploadB64.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhuma imagem foi encontrado com o id informado." });
        }

        private bool IsBase64String(string stringBase64)
        {
            Span<byte> buffer = new Span<byte>(new byte[stringBase64.Length]);
            return Convert.TryFromBase64String(stringBase64, buffer, out int bytesParsed);
        }

        /// <summary>
        /// Converte a imagem em base64.
        /// Nome: formFile.
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("Conversor-Base64")]
        public IActionResult ConversorBase64([FromForm] PostConversorDto formFile)
        {
            if (formFile.ImagemUpload.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    formFile.ImagemUpload.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();

                    ViewConversorDto image = new ViewConversorDto();
                    image.ImagemEmBase64 = Convert.ToBase64String(fileBytes);
                    return Ok(image);
                }
            }
            return null;
        }
    }
}