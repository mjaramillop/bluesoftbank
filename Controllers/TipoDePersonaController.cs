using bluesoftbank.Models;
using bluesoftbank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bluesoftbank.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class TipoDePersonaController : ControllerBase
    {

        private readonly TipoDePersonaService _service;

        public TipoDePersonaController(TipoDePersonaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<TipoDePersona>? GetAll()
        {

            List<TipoDePersona> list = _service.List();
            return list;
        }

    }


}
