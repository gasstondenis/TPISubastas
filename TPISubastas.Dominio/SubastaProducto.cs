using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace TPISubastas.Dominio
{
    public class SubastaProducto
    {
        public int IdSubastaProducto { get; set; }
        [Display(Name="Subasta")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar una subasta")]
        public int IdSubasta { get; set; }
        [Display(Name = "Nombre del producto")]
        [Required]
        [MaxLength(256)]
        public string NombreProducto { get; set; }
        [Required]
        [MaxLength(128)]
        [Display(Name = "Marca del producto")]
        public string MarcaProducto { get; set; }
        [Required]
        [Display(Name = "Descripcion del producto")]
        [MaxLength(4096)]
        public string DescripcionProducto { get; set; }
        [Required]
        [MaxLength(1024)]
        [Display(Name = "Url de la imagen")]
        [DataType(DataType.Url)]
        public string ImagenProducto { get; set; }
        [Required]
        [Display(Name = "Forma de pago")]
        [MaxLength(256)]
        public string FormaPago { get; set; }

        [Display(Name = "Monto inicial")]
        [Required]
        public decimal MontoInicial { get; set; }
        public int IdUsuario { get; set; }
        public int? IdUsuarioComprador { get; set; }
        public int? IdProducto { get; set; }
        public int IdEstadoSubasta { get; set; }

        public bool Notificado { get; set; }
    }
}
