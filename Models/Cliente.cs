using System;
using System.Collections.Generic;

namespace bluesoftbank.Models;

public  class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Saldo { get; set; }

    public int? Tipodecuenta { get; set; }

    public int? Tipodepersona { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual Tipodepersona? TipodepersonaNavigation { get; set; }
}
