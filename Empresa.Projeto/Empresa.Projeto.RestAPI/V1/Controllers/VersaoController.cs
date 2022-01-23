using Microsoft.AspNetCore.Mvc;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/versao")]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        /// <summary>
        /// Versão
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Valor()
        {
            return "Sou a V1";
        }
    }
}
