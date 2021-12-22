using System;
using System.ComponentModel.DataAnnotations;

namespace TPISubastas.Dominio
{
    public class Subasta
    {

        public int IdSubasta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaCierre { get; set; }
        public int Duracion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitada { get; set; }

    }
}
