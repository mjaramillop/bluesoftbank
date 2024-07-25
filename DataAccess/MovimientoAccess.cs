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
            obj.fecha = System.DateTime.Now;
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

        public List<Movimiento> ConsultarMovimiento(Movimiento obj)
        {
            List<Movimiento> list = _context.Movimientos.Where(a => a.idcliente == obj.idcliente && a.fecha >= System.DateTime.Now.AddDays(obj.valor * -1)).OrderByDescending(a => a.fecha).ToList();

            return list;
        }

        public List<Movimiento> Extracto(Movimiento obj)
        {
            int ano = obj.fecha.Year;
            int mes = obj.fecha.Month;
            int dia = 01;
            DateTime fechadesde = new DateTime(ano, mes, dia);

            List<Movimiento> list = _context.Movimientos.Where(a => a.idcliente == obj.idcliente && (a.fecha >= fechadesde && a.fecha <= obj.fecha)).OrderBy(a => a.fecha).ToList();

            return list;
        }

        public List<Movimiento> TotalTransaccionesPorMes(Movimiento obj)
        {

            int ano = obj.fecha.Year;
            int mes = obj.fecha.Month;
            int dia = 01;
            DateTime fechadesde = new DateTime(ano, mes, dia);
            int ano2 = obj.fecha.Year;
            int mes2 = obj.fecha.Month+1;
            if (mes2 > 12) mes2 = 1;
            int dia2 = 01;
            DateTime fechahasta = new DateTime(ano2, mes2, dia2);


            List<Movimiento> list = _context.Movimientos.
                Where(a => a.fecha >= fechadesde && a.fecha <fechahasta).
                GroupBy(a => a.nombrecliente).Select(cl => new Movimiento
            {

              nombrecliente = cl.First().nombrecliente,
              valor = cl.Count(),
            }).ToList();

            return list;
        }

        public List<Movimiento> RetirosFueraDeLaCiudad()
        {


            List<Movimiento> list = _context.Movimientos.
                Where(a => a.movimientolocal=="N" && a.movimientodebitoocredito=="C" ).
                GroupBy(a => a.nombrecliente).Select(cl => new Movimiento
                {
                    nombrecliente = cl.First().nombrecliente,
                    valor = cl.Sum(a=>a.valor ),
                }).Where(s =>s.valor>1000000).OrderBy(a =>a.nombrecliente ).ToList();




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

            if ("SN".IndexOf(obj.movimientolocal) < 0)
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
            TipoDeMovimiento objtipodemovimiento = _context.TipoDeMovimiento.FirstOrDefault(a => a.id == obj.tipodemovimiento);
            obj.nombremovimiento = objtipodemovimiento.nombre;
            obj.movimientodebitoocredito = objtipodemovimiento.debitocredito;

            return obj;
        }
    }
}