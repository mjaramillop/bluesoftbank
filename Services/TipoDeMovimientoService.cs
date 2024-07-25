using bluesoftbank.DataAccess;
using bluesoftbank.Models;

namespace bluesoftbank.Services
{

    public class TipoDeMovimientoService
    {

        private readonly TipoDeMovimientoAccess _context;

        public TipoDeMovimientoService(TipoDeMovimientoAccess context)
        {
            _context = context;
        }

        public List<TipoDeMovimiento>? List()
        {
            List<TipoDeMovimiento> list = _context.List();
            return list;
        }



    }





}
