﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TPISubastas.Dominio
{
    public class Oferta
    {
        public int IdOferta { get; set; }
        public int IdSubasta { get; set; }
        public int IdSubastaProducto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        //Propidades de Navegacion
        //public virtual Usuario Usuario { get; set; }
        //public virtual Subasta Subasta { get; set; }

    }
}
