using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TPISubastas.Dominio
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        [Required]
        [MaxLength(256)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(256)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(64)]
        public string Documento { get; set; }
        [MaxLength(1024)]
        public string Calle { get; set; }
        [MaxLength(64)]
        public string Numero { get; set; }
        [MaxLength(64)]
        public string CodigoPostal { get; set; }
        [MaxLength(1024)]
        public string Ciudad { get; set; }
        [MaxLength(128)]
        public string Provincia { get; set; }
        [MaxLength(64)]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCreacion { get; set; }

        //Propiedad de Navegacion
        //public IList<Subasta> Subastas { get; set; }
        //public IList<Oferta> Ofertas { get; set; }
    }
}
