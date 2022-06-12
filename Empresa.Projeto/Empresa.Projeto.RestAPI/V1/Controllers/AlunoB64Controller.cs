using Empresa.Projeto.Application.Dtos.AlunoB64;
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

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/AlunoBase64")]
    [ApiController]
    public class AlunoB64Controller : ControllerBase
    {
        private readonly IApplicationAlunoB64 applicationAlunoB64;

        private Caminhos[] urls;

        public AlunoB64Controller(IApplicationAlunoB64 applicationAlunoB64)
        {
            this.applicationAlunoB64 = applicationAlunoB64;
            PopulateURLs();
        }

        private void PopulateURLs()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"../../Empresa.Projeto/Empresa.Projeto.RestAPI/URLs/Diretorios.json");
            string json = System.IO.File.ReadAllText(path);
            urls = JsonConvert.DeserializeObject<Caminhos[]>(json);
        }

        /// <summary>
        /// Retorna todos os alunos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewAlunoB64Dto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ViewAlunoB64Dto> result = await applicationAlunoB64.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum aluno foi encontrado." });
        }

        /// <summary>
        /// Retorna um aluno consultado via id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ViewAlunoB64Dto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            ViewAlunoB64Dto result = await applicationAlunoB64.GetByIdAsync(id);

            if (result != null)
                return Ok(result);

            return NotFound(new { mensagem = "Nenhum aluno foi encontrado com o id informado." });
        }

        /// <summary>
        /// Adiciona um aluno ao banco e uma imagem em um diretório escolhido por parâmetro.
        /// </summary>
        /// <param name="postAlunoDto"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostUploadB64(PostAlunoB64Dto postAlunoDto, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (postAlunoDto.ImagemEmBase64 == null || !IsBase64String(postAlunoDto.ImagemEmBase64))
                return BadRequest(new { mensagem = "Insira uma imagem!" });

            if ((int)diretorio > urls.Length || diretorio == 0)
                return BadRequest(new { mensagem = "Diretório não encontrado." });

            ViewAlunoB64Dto objeto = await applicationAlunoB64.PostAsync(postAlunoDto, urls[(int)diretorio - 1].diretoriosAbsolutos, urls[(int)diretorio - 1].diretoriosRelativos);

            return Ok(new { mensagem = "Aluno criado com sucesso.", objeto.IdGuid, objeto.CaminhoRelativo });
        }

        /// <summary>
        /// Altera um aluno cadastrado com novos dados.
        /// </summary>
        /// <param name="putAlunoDto"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutUpload(PutAlunoB64Dto putAlunoDto, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (putAlunoDto.ImagemEmBase64 == null || !IsBase64String(putAlunoDto.ImagemEmBase64))
                return BadRequest(new { mensagem = "Insira uma imagem!" });

            if ((int)diretorio > urls.Length || diretorio == 0)
                return BadRequest(new { mensagem = "Diretório não encontrado." });

            ViewAlunoB64Dto objeto = await applicationAlunoB64.PutAsync(putAlunoDto, urls[(int)diretorio - 1].diretoriosAbsolutos, urls[(int)diretorio - 1].diretoriosRelativos);

            if (objeto is null)
                return NotFound(new { mensagem = "Id de aluno não encontrado." });

            return Ok(new { mensagem = "Aluno alterado com sucesso.", objeto.IdGuid, objeto.CaminhoRelativo });
        }

        /// <summary>
        /// Exclui um aluno.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um aluno o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ViewAlunoB64Dto result = await applicationAlunoB64.DeleteAsync(id);
            if (result != null)
                return Ok(new { mensagem = "Aluno removido com sucesso!" });

            return NotFound(new { mensagem = "Nenhum aluno foi encontrado com o id informado." });
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

            ViewAlunoB64Dto result = await applicationAlunoB64.PutStatusAsync(id, status);
            if (result != null)
                return Ok(new { mensagem = "Status atualizado com sucesso para: " + status });

            return NotFound(new { mensagem = "Nenhum aluno foi encontrado com o id informado." });
        }

        private bool IsBase64String(string stringBase64)
        {
            Span<byte> buffer = new Span<byte>(new byte[stringBase64.Length]);
            return Convert.TryFromBase64String(stringBase64, buffer, out int bytesParsed);
        }
    }
}
