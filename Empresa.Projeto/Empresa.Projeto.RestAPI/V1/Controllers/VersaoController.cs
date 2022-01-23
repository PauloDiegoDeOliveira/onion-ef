using Microsoft.AspNetCore.Mvc;

namespace Empresa.Projeto.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/versao")]
    public class VersaoController : ControllerBase
    {
        [HttpGet]
        public string Valor()
        {
            return "Sou a V1";
        }
    }
}
