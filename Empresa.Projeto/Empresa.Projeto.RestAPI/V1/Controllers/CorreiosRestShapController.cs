using Empresa.Projeto.Application.Dtos.Correios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/CorreiosRestSharp")]
    [ApiController]
    public class CorreiosRestShapController : ControllerBase
    {
        /// <summary>
        /// Teste para consumir via CEP com RestSharp.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpGet("viaCEP")]
        public async Task<IActionResult> RestSharp(string cep)
        {
            var cliente = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            RestRequest requisicao = new RestRequest("", Method.Get);
            var resposta = await cliente.ExecuteAsync(requisicao);
            if (!resposta.IsSuccessful)
            {
                return NotFound(new { mensagem = "CEP não encontrado!" });
            }
            var resultado = JsonConvert.DeserializeObject<ViewCorreiosDto>(resposta.Content);
            return Ok(resultado);
        }
    }
}