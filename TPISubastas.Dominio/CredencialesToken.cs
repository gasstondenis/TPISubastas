using System;
using System.Collections.Generic;
using System.Text;

namespace TPISubastas.Dominio
{
    public class TokenSeguridad
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }

    public class CredencialesToken
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
