using bluesoftbank.Models;

namespace bluesoftbank.DataAccess
{
    public class MovimientoAccess
    {
        private readonly BluesoftBankContext _context;

        public MovimientoAccess(BluesoftBankContext context)
        {
            _context = context;
        }

        public List<Movimiento> Add(Movimiento obj)
        {
            List<Movimiento> list = new List<Movimiento>();
            obj = pasarnombres(obj);
            string mensajederror = this.ValidarRegistro(obj);

            if (mensajederror.Trim().Length > 0)
            {
                Movimiento obj2 = new Movimiento();
                obj2.mensajedeerror = mensajederror;
                list.Add(obj2);
                return list;
            }


            // update saldo cliente
            var objcliente = _context.Clientes.FirstOrDefault(a => a.id == obj.idcliente);
            if (obj.movimientodebitoocredito == "D")
            {
                objcliente.saldo = objcliente.saldo + obj.valor;
            }
            if (obj.movimientodebitoocredito == "C")
            {
                objcliente.saldo = objcliente.saldo - obj.valor;
            }
            _context.SaveChanges();


            obj.saldo = objcliente.saldo;
            _context.Movimientos.Add(obj);
            _context.SaveChanges();


            list = _context.Movimientos.Where(a => a.idcliente == obj.idcliente).OrderBy(a => a.fecha).ToList();

            return list;
        }

        public string ValidarRegistro(Movimiento obj)
        {
            string mensajedeerror = "";

            if (obj.movimientodebitoocredito == "C")
            {
                if ((obj.saldo - obj.valor) < 0)
                {
                    mensajedeerror = mensajedeerror = "No tiene saldo suficiente para descargar";
                }
            }

            if ("SN".IndexOf(obj.movimientolocal)<0)
            {

                mensajedeerror = mensajedeerror = "Debes incluir si el movimiento es local S o No N ";

            }

            return mensajedeerror;
        }

        public Movimiento pasarnombres(Movimiento obj)
        {
            Cliente? objcliente = _context.Clientes.FirstOrDefault(a => a.id == obj.idcliente);
            obj.nombrecliente = objcliente.nombre;
            obj.saldo = objcliente.saldo;
            Tipodemovimiento objtipodemovimiento = _context.Tipodemovimientos.FirstOrDefault(a => a.id == obj.tipodemovimiento);
            obj.nombremovimiento = objtipodemovimiento.nombre;
            obj.movimientodebitoocredito = objtipodemovimiento.debitocredito;

            return obj;
        }
    }
}