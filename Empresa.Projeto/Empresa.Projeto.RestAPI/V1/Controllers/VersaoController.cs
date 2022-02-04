using Microsoft.AspNetCore.Mvc;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Versao")]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        /// <summary>
        /// Informa a versão da API.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Valor()
        {
            return "Esta é a versão V1.";
        }
    }
}