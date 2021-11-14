using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.Dominio;

namespace TPISubastas.Sitio.Security
{
    public class SecurityLogin
    {
        [MinLength(8)]
        [Display(Name ="Nombre de usuario")]
        [Required]
        public string Usuario { get; set; }
        [MinLength(8)]
        [Required]
        public string Contraseña { get; set; }

    }

    public class SecurityRegister : Usuario
    {
        [MinLength(8)]
        [Display(Name = "Nombre de usuario")]
        [Required]
        public string Usuario { get; set; }
        [MinLength(8)]
        [Required]
        public string Contraseña { get; set; }
        [MinLength(8)]
        [Required]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas ingresadas deben ser iguales")]
        public string RepetirContraseña { get; set; }
    }

    public class SecurityRole : IdentityRole
    {

    }

    public class SecurityUser : IdentityUser
    {
        public int? IdUsuarioSubasta { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    public class SecurityContext : IdentityDbContext<SecurityUser, SecurityRole, string>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {

        }
    }
}
