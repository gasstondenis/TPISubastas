using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TPISubastas.Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        [MaxLength(256)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(128)]
        public string Marca { get; set; }
        [Required]
        [MaxLength(4096)]
        public string Descripcion { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
