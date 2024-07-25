using bluesoftbank.Models;
using bluesoftbank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bluesoftbank.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]


    public class TipoDeCuentaController : ControllerBase
    {



        private readonly TipoDeCuentaService _service;




        public TipoDeCuentaController(TipoDeCuentaService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<TipoDeCuenta>? GetAll()
        {

            List<TipoDeCuenta> list = _service.List();
            return list;
        }

    }

}
