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
        [Required]
        [MaxLength(256)]
        public string NombreProducto { get; set; }
        [Required]
        [MaxLength(128)]
        public string MarcaProducto { get; set; }
        [Required]
        [MaxLength(4096)]
        public string DescripcionProducto { get; set; }
        [Required]
        [MaxLength(1024)]
        public string ImagenProducto { get; set; }
        [Required]
        [MaxLength(256)]
        public string FormaPago { get; set; }
        [Required]
        public decimal MontoInicial { get; set; }


        public int IdEstadoSubasta { get; set; }
        public int IdUsuario { get; set; }
        public int? IdUsuarioComprador { get; set; }
        public int? IdProducto { get; set; }
    }
}
