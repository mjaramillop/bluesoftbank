using bluesoftbank.Models;

namespace bluesoftbank.DataAccess
{
    public class TipoDeMovimientoAccess
    {

        private readonly BluesoftBankContext _context;

        public TipoDeMovimientoAccess(BluesoftBankContext context)
        {
            _context = context;
        }

        public List<TipoDeMovimiento>? List()
        {
            List<TipoDeMovimiento> list = _context.TipoDeMovimiento.ToList().OrderBy(a => a.nombre).ToList();
            return list;
        }



    }
}
