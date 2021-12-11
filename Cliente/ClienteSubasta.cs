using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TPISubastas.Dominio;


namespace Cliente
{
    public class ClienteSubasta
    {
        private string _Dominio = null;
        private string _baseapi = null;
        public ClienteSubasta(string dominio)
        {
            _Dominio = dominio;
            _baseapi = dominio + "api/SubastaAPI/";
        }
        public List<Subasta> Listar()
        {
            List<Subasta> resultado = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseapi);
                var response = client.GetAsync("").GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var textorespuesta = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    resultado = JsonConvert.DeserializeObject<List<Subasta>>(textorespuesta);
                }
                else
                {
                    throw new Exception("No se ha podido recuperar las entidades");
                }
            }
            return resultado;
        }
        public Subasta Obtener(int Id)
        {
            Subasta resultado = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseapi);
                var response = client.GetAsync(Id.ToString()).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var textorespuesta = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    resultado = JsonConvert.DeserializeObject<Subasta>(textorespuesta);
                }
                else
                {
                    throw new Exception("No se ha podido recuperar la entidad");
                }
            }
            return resultado;
        }
        public void Agregar(Subasta elemento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseapi);
                DefaultContractResolver resolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
                var serializado = JsonConvert.SerializeObject(elemento, new JsonSerializerSettings()
                {
                    ContractResolver = resolver,
                    Formatting = Formatting.None
                });
                HttpContent mensaje = new StringContent(serializado, Encoding.UTF8, "application/json");
                var response = client.PostAsync("", mensaje).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No se ha podido Agregar la entidad");
                }
            }
        }

        public void Actualizar(Subasta elemento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseapi);
                DefaultContractResolver resolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
                var serializado = JsonConvert.SerializeObject(elemento, new JsonSerializerSettings()
                {
                    ContractResolver = resolver,
                    Formatting = Formatting.None
                });
                HttpContent mensaje = new StringContent(serializado, Encoding.UTF8, "application/json");
                var response = client.PostAsync(elemento.IdSubasta.ToString(), mensaje).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No se ha podido Agregar la entidad");
                }
            }
        }
        public void Eliminar(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseapi);
                var response = client.DeleteAsync(id.ToString()).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No se ha podido recuperar la entidad");
                }
            }
        }
    }
}
