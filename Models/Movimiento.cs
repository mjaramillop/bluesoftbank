using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace bluesoftbank.Models;

public  class Movimiento
{

    public Movimiento()
    {
      
       this.id=0;
        this.idcliente=0;   
        this.tipodemovimiento=0;    
        this.valor=0;
        this.fecha = DateTime.Now;
        this.movimientolocal = "S";
        this.mensajedeerror = "";
        this.nombremovimiento = "";
        this.nombrecliente = "";
        this.movimientodebitoocredito = "";
        this.saldo = 0;

    }


    public int id { get; set; }

    public int idcliente { get; set; }

    public int tipodemovimiento { get; set; }

    public int valor { get; set; }

    public DateTime fecha { get; set; }

   public string movimientolocal { get; set; }

    
    public string mensajedeerror { get; set; }

   
    public string nombremovimiento { get;set; }


 
    public string nombrecliente { get; set; }

   

    public string movimientodebitoocredito { get; set; }


    public int saldo { get; set; }  
}
