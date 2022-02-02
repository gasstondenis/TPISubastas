using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TPISubastas.Dominio;
using Cliente.LoginModel;
using System.Security.Cryptography;



namespace Cliente
{
   public class ClienteAPI<T>
   {
      private string _Dominio = null;
      private string _baseapi = null;
      private string _baseseguridad = null;
      private string _Usuario = null;
      private string _Contraseña = null;
      private TokenSeguridad _token = null;
      public bool estadoCredenciales;

      public ClienteAPI(string dominio, string Nombre, string Usuario, string Contraseña)
      {
         _Dominio = dominio;
         _baseapi = dominio + "api/" + Nombre + "API/";
         _baseseguridad = dominio + "Account/";
         _Usuario = Usuario;
         _Contraseña = Contraseña;
      }

      private StringContent GenerarMensaje(object contenido)
      {
         DefaultContractResolver resolver = new DefaultContractResolver()
         {
            NamingStrategy = new CamelCaseNamingStrategy()
         };
         var serializado = JsonConvert.SerializeObject(contenido, new JsonSerializerSettings()
         {
            ContractResolver = resolver,
            Formatting = Formatting.None
         });
         return new StringContent(serializado, Encoding.UTF8, "application/json");
      }

      private void AsegurarToken()
      {
         if (_token == null)
         {
            RenovarToken();
         }
      }


      private void RenovarToken()
      {
         using (var client = new HttpClient())
         {
            client.BaseAddress = new Uri(_baseseguridad);
            var contenido = GenerarMensaje(new CredencialesToken() { Usuario = _Usuario, Contraseña = _Contraseña });
            var resultado = client.PostAsync("ObtenerToken", contenido).GetAwaiter().GetResult();

            if (resultado.IsSuccessStatusCode)
            {
               var resultadoString = resultado.Content.ReadAsStringAsync().GetAwaiter().GetResult();
               try
               {
                  _token = JsonConvert.DeserializeObject<TokenSeguridad>(resultadoString);
                  estadoCredenciales = true;
                  
               }
               catch (Exception ex)
               {
                  estadoCredenciales = false;
                  //throw new Exception("Error de autentificación", ex);

               }
               if (_token != null && _token.Token == "ERROR")
               {
                  estadoCredenciales = false;
                  //throw new Exception("Ërror de autenticación. Credenciales incorrectas");

               }
               else if (_token == null)
               {
                  estadoCredenciales = false;
                  //throw new Exception("Error de autentificación");
               }
            }
            else
            {
               throw new Exception(string.Format("Error de autentificación {0}", resultado.StatusCode));
            }
         }
      }
      public List<T> Listar()
      {
         AsegurarToken();
         List<T> resultado = null;
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
               resultado = JsonConvert.DeserializeObject<List<T>>(textorespuesta);
            }
            else
            {
               throw new Exception("No se ha podido recuperar las entidades");
            }
         }
         return resultado;
      }
      
      

      public T Obtener(int Id)
      {
         AsegurarToken();
         T resultado = default(T);
         using (var client = new HttpClient())
         {
            client.BaseAddress = new Uri(_baseapi);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
            var response = client.GetAsync(Id.ToString()).GetAwaiter().GetResult();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
               _token = null;
               AsegurarToken();
               client.DefaultRequestHeaders.Remove("Authorization");
               client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
               response = client.GetAsync(Id.ToString()).GetAwaiter().GetResult();
            }
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
               var textorespuesta = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
               resultado = JsonConvert.DeserializeObject<T>(textorespuesta);
            }
            else
            {
               throw new Exception("No se ha podido recuperar la entidad");
            }
         }
         return resultado;
      }
      
      public void Agregar(T elemento)
      {
         AsegurarToken();
         using (var client = new HttpClient())
         {
            client.BaseAddress = new Uri(_baseapi);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
            HttpContent mensaje = GenerarMensaje(elemento);
            var response = client.PostAsync("", mensaje).GetAwaiter().GetResult();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
               _token = null;
               AsegurarToken();
               client.DefaultRequestHeaders.Remove("Authorization");
               client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
               response = client.PostAsync("", mensaje).GetAwaiter().GetResult();
            }
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
            {
               throw new Exception("No se ha podido Agregar la entidad");
            }
         }
      }

      public bool Login()
      {
         RenovarToken();
         if (estadoCredenciales)
         {                                             
            return true;
         }
         return false;
      }


      public void Actualizar(T elemento, string Id)
      {
         AsegurarToken();
         using (var client = new HttpClient())
         {
            client.BaseAddress = new Uri(_baseapi);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
            HttpContent mensaje = GenerarMensaje(elemento);
            var response = client.PutAsync(Id, mensaje).GetAwaiter().GetResult();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
               _token = null;
               AsegurarToken();
               client.DefaultRequestHeaders.Remove("Authorization");
               client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
               response = client.PutAsync(Id, mensaje).GetAwaiter().GetResult();
            }
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
            {
               throw new Exception("No se ha podido Agregar la entidad");
            }
         }
      }
      public void Eliminar(int id)
      {
         AsegurarToken();
         using (var client = new HttpClient())
         {
            client.BaseAddress = new Uri(_baseapi);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
            var response = client.DeleteAsync(id.ToString()).GetAwaiter().GetResult();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
               _token = null;
               AsegurarToken();
               client.DefaultRequestHeaders.Remove("Authorization");
               client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token.Token);
               response = client.DeleteAsync(id.ToString()).GetAwaiter().GetResult();
            }
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
            {
               throw new Exception("No se ha podido recuperar la entidad");
            }
         }
      }


   }
}
