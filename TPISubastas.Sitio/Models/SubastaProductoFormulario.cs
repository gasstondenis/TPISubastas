using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TPISubastas.Sitio.Models
{
    public class SubastaProductoFormulario : SubastaProducto
    {
        public List<SelectListItem> SubastasDisponibles { get; set; }
        
        public List<SelectListItem> OpcionesPago { get; set; }
    }
}
