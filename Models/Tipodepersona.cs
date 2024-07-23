using System;
using System.Collections.Generic;

namespace bluesoftbank.Models;

public class Tipodepersona
{
    public int Id { get; set; }

    public string? Tipodepersona1 { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
