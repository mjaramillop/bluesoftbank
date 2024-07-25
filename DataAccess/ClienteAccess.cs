using bluesoftbank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace bluesoftbank.DataAccess
{
    public class ClienteAccess
    {

        private readonly BluesoftBankContext _context ;

        public ClienteAccess(BluesoftBankContext context)
        {
            _context = context;
        }

        public List<Cliente>? List()
        {
           List<Cliente> list = _context.Clientes.ToList().OrderBy(a => a.nombre).ToList();
            return list;
        }

        public List<Cliente>? ConsultarSaldo(int idcliente)
        {
            List<Cliente> list = _context.Clientes.Where(a => a.id==idcliente).ToList();
            return list;
        }



    }
}
