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

      

    }
}
