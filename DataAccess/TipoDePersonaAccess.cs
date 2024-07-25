using bluesoftbank.Models;

namespace bluesoftbank.DataAccess
{
    public class TipoDePersonaAccess
    {

        private readonly BluesoftBankContext _context;

        public TipoDePersonaAccess(BluesoftBankContext context)
        {
            _context = context;
        }

        public List<TipoDePersona>? List()
        {
            List<TipoDePersona> list = _context.TipoDePersona.ToList().OrderBy(a => a.nombre).ToList();
            return list;
        }



    }
}
