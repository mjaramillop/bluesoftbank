using bluesoftbank.Models;
using bluesoftbank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bluesoftbank.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]


    public class ClienteController : ControllerBase
    {

        private readonly ClienteService _service;


        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<Cliente>? GetAll()
        {

            List<Cliente> list = _service.List();
            return list;
        }

        [HttpGet("{idcliente}")]
        [ActionName("ConsultarSaldo")]
        public List<Cliente>? ConsultarSaldo(int idcliente)
        {

            List<Cliente> list = _service.ConsultarSaldo(idcliente);
            return list;
        }



    }

}
