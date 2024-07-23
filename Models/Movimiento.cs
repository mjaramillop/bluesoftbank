using System;
using System.Collections.Generic;

namespace bluesoftbank.Models;

public  class Movimiento
{
    public int Id { get; set; }

    public int? Idcliente { get; set; }

    public int? Tipodemovimiento { get; set; }

    public int? Valor { get; set; }

    public DateTime? Fecha { get; set; }

   public string Movimientolocal { get; set; }
}
