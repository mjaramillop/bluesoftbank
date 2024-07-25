using bluesoftbank.Models;
using bluesoftbank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace bluesoftbank.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    
    
    
    public class TipoDeMovimientoController : ControllerBase
    {



        private readonly TipoDeMovimientoService _service;

      


        public TipoDeMovimientoController(TipoDeMovimientoService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<TipoDeMovimiento>? GetAll()
        {
          
          List<TipoDeMovimiento>  list = _service.List();
            return list;
        }

    }







}
