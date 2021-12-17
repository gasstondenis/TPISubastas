using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.Dominio;
using System.ComponentModel.DataAnnotations;
namespace TPISubastas.Sitio.Models
{
    public class SubastaDetalle
    {
        public List<SubastaProducto> Productos { get; set; }
        public SubastaProducto detalleProducto { get; set; }

        [Display(Name ="Oferta realizada")]
        public decimal ofertaRealizada { get; set; }

        
        
    }
}
