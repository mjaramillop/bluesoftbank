using bluesoftbank.Models;
using bluesoftbank.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bluesoftbank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {


        private readonly MovimientoService _service;

        public MovimientoController(MovimientoService service)
        {
            _service = service;
        }



        // GET: api/<MovimientoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public List<Movimiento> Add( Movimiento obj)
        {
          return   _service.Add(obj);  
        }

       

    }
}
