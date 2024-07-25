using bluesoftbank.DataAccess;
using bluesoftbank.Models;

namespace bluesoftbank.Services
{


    public class ClienteService
    {

        private readonly ClienteAccess _context;

        public ClienteService(ClienteAccess context)
        {
            _context = context;
        }

        public List<Cliente>? List()
        {
            List<Cliente> list = _context.List();
            return list;
        }

        public List<Cliente>? ConsultarSaldo(int idcliente)
        {
            List<Cliente> list = _context.ConsultarSaldo(idcliente);
            return list;
        }



    }


}



