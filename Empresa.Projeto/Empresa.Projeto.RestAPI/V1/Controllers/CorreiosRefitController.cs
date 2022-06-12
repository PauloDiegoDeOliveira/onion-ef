using Empresa.Projeto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/CorreiosRefit")]
    [ApiController]
    public class CorreiosRefitController : ControllerBase
    {
        private readonly IApplicationCorreios applicationCorreios;

        public CorreiosRefitController(IApplicationCorreios applicationCorreios)
        {
            this.applicationCorreios = applicationCorreios;
        }

        /// <summary>
        /// Teste para consumir via CEP com Refit.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpGet("viaCEP")]
        public async Task<IActionResult> GetCepCorreios(string cep)
        {
            try
            {
                var consulta = await applicationCorreios.GetCep(cep);
                return Ok(consulta);
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = "CEP não encontrado. " + e.Message });
            }
        }
    }
}