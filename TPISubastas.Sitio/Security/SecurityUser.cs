using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPISubastas.Sitio.Security
{
    public class SecurityLogin
    {
        [MinLength(8)]
        [Display(Name ="Nombre de usuario")]
        public string Usuario { get; set; }
        [MinLength(8)]
        public string Contraseña { get; set; }

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
