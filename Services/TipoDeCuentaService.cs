using bluesoftbank.DataAccess;
using bluesoftbank.Models;

namespace bluesoftbank.Services
{
    public class TipoDeCuentaService
    {

        private readonly TipoDeCuentaAccess _context;

        public TipoDeCuentaService(TipoDeCuentaAccess context)
        {
            _context = context;
        }

        public List<TipoDeCuenta>? List()
        {
            List<TipoDeCuenta> list = _context.List();
            return list;
        }



    }

}
