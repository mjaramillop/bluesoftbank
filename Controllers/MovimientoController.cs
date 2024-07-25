using bluesoftbank.Models;
using bluesoftbank.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bluesoftbank.Controllers
{
    [Route("[controller]/[action]")]

    [ApiController]
    public class MovimientoController : ControllerBase
    {


        private readonly MovimientoService _service;

        public MovimientoController(MovimientoService service)
        {
            _service = service;
        }



     

        // POST api/<MovimientoController>
        [HttpPost]
        [ActionName("Add")]
        public List<Movimiento> Add( Movimiento obj)
        {
          return   _service.Add(obj);  
        }


        [HttpPost]
        [ActionName("ConsultarMovimiento")]
        public List<Movimiento> ConsultarMovimiento(Movimiento obj)
        {
            return _service.ConsultarMovimiento(obj);
        }


        [HttpPost]
        [ActionName("Extracto")]
        public List<Movimiento> Extracto(Movimiento obj)
        {
            return _service.Extracto(obj);
        }



        [HttpPost]
        [ActionName("TotalTransaccionesPorMes")]
        public List<Movimiento> TotalTransaccionesPorMes(Movimiento obj)
        {
            return _service.TotalTransaccionesPorMes(obj);
        }


        [HttpGet]
        [ActionName("RetirosFueraDeLaCiudad")]
        public List<Movimiento> RetirosFueraDeLaCiudad()
        {
            return _service.RetirosFueraDeLaCiudad();
        }

    }
}
