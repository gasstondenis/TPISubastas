using Cliente.LoginModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class LoginAPI
    {
        private string _Dominio = null;
        private string _baseapi = null;
        private string _baseseguridad = null;
        private string _Usuario = null;
        private string _Contraseña = null;

        public LoginAPI(string dominio, string Nombre, string Usuario, string Contraseña)
        {
            _Dominio = dominio;
            _baseapi = dominio + "api/" + Nombre + "API/";
            _baseseguridad = dominio + "Account/";
            _Usuario = Usuario;
            _Contraseña = Contraseña;
        }


       /* public User Login()
        {
            AsegurarToken();
            User resultado = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseapi);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
                var response = client.GetAsync("").GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    _token = null;
                    AsegurarToken();
                    client.DefaultRequestHeaders.Remove("Authorization");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
                    response = client.GetAsync("").GetAwaiter().GetResult();
                }
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var textorespuesta = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    resultado = JsonConvert.DeserializeObject<User>(textorespuesta);
                }
            }
            return resultado;
        }
       */

    }
}
