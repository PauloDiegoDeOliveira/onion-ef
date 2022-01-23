using Microsoft.AspNetCore.Mvc;

namespace Empresa.Projeto.RestAPI.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/versao")]
    public class VersaoController : ControllerBase
    {
        [HttpGet]
        public string Valor()
        {
            return "Sou a V2";
        }
    }
}
