using bluesoftbank.Models;

namespace bluesoftbank.DataAccess
{


    public class TipoDeCuentaAccess
    {

        private readonly BluesoftBankContext _context;

        public TipoDeCuentaAccess(BluesoftBankContext context)
        {
            _context = context;
        }

        public List<TipoDeCuenta>? List()
        {
            List<TipoDeCuenta> list = _context.TipoDeCuenta.ToList().OrderBy(a => a.nombre).ToList();
            return list;
        }



    }
}
