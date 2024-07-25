using bluesoftbank.DataAccess;
using bluesoftbank.Models;

namespace bluesoftbank.Services
{
    public class TipoDePersonaService
    {

        private readonly TipoDePersonaAccess _context;

        public TipoDePersonaService(TipoDePersonaAccess context)
        {
            _context = context;
        }

        public List<TipoDePersona>? List()
        {
            List<TipoDePersona> list = _context.List();
            return list;
        }



    }
}
