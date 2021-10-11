using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TPISubastas.Dominio
{
    public class EstadoSubasta
    {
        public int IdEstadoSubasta { get; set; }
        [Required]
        [MaxLength(64)]
        public string Nombre { get; set; }
        [MaxLength(64)]
        public string Descripcion { get; set; }
    }
}
