using bluesoftbank.DataAccess;
using bluesoftbank.Models;

namespace bluesoftbank.Services
{
    public class MovimientoService
    {

        private readonly MovimientoAccess _access;

        public MovimientoService(MovimientoAccess access)
        {
            _access = access;
        }

        public List<Movimiento> Add(Movimiento obj)
        {
           List<Movimiento> list = _access.Add(obj);
            return list;
        }


        public List<Movimiento> ConsultarMovimiento(Movimiento obj)
        {
            List<Movimiento> list = _access.ConsultarMovimiento(obj);
            return list;
        }


        public List<Movimiento> Extracto(Movimiento obj)
        {
            List<Movimiento> list = _access.Extracto(obj);
            return list;
        }


        public List<Movimiento> TotalTransaccionesPorMes(Movimiento obj)
        {
            List<Movimiento> list = _access.TotalTransaccionesPorMes(obj);
            return list;
        }


        public List<Movimiento> RetirosFueraDeLaCiudad()
        {
            List<Movimiento> list = _access.RetirosFueraDeLaCiudad();
            return list;
        }

    }
}
