using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace bluesoftbank.Models;

public  class Cliente
{


    public Cliente()
    {
        this.id = 0;
        this.nombre = "";
        this.saldo = 0;
        this.tipodecuenta = 0;  
        this.tipodepersona = 0;


    }

    public int id { get; set; }

    public string nombre { get; set; }

    public int saldo { get; set; }

    public int tipodecuenta { get; set; }

    public int tipodepersona { get; set; }

  
}
