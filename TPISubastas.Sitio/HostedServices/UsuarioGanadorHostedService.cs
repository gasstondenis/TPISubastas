using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.Dominio;
using TPISubastas.AccesoDatos;
using Microsoft.Extensions.Hosting;
using System.Threading;
using TPISubastas.Sitio.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TPISubastas.Sitio.HostedServices
{
   public class UsuarioGanadorHostedService : IHostedService, IDisposable
   {
      //Este servicio notifica a los usuarios ganadores y a los usuarios vendedores cuyos productos no hayan recibido ofertas via mail


      private IServiceScopeFactory _ScopeFactory;
      private Timer _timer;


      public UsuarioGanadorHostedService(IServiceScopeFactory scopeFactory)
      {
         _ScopeFactory = scopeFactory;
      }

      public Task StartAsync(CancellationToken cancellationToken)
      {
         _timer = new Timer(ObtenerGanadores, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
         return Task.CompletedTask;
      }

      public Task StopAsync(CancellationToken cancellationToken)
      {
         _timer?.Change(Timeout.Infinite, 0);
         return Task.CompletedTask;
      }
      public void Dispose()
      {
         _timer?.Dispose();
      }

      public void ObtenerGanadores(object state)
      {
         using (var scope = _ScopeFactory.CreateScope())
         {
            var _ContextoSubasta = scope.ServiceProvider.GetRequiredService<ContextoSubasta>();

            var subastas = _ContextoSubasta.Subasta.Where(x => x.FechaCierre <= DateTime.Now || !x.Habilitada).Select(x => x.IdSubasta).ToList();
            var productos = _ContextoSubasta.SubastaProducto.Where(x => (x.IdEstadoSubasta == 3 || x.IdEstadoSubasta == 5) && !x.Notificado && subastas.Contains(x.IdSubasta)).ToList();
            SubastaProducto producto = new SubastaProducto();


            foreach (var item2 in productos)
            {
               producto = item2;
               var oferta = _ContextoSubasta.Oferta.Where(x => x.IdSubastaProducto == producto.IdSubastaProducto).OrderByDescending(x => x.Monto).FirstOrDefault();
               if (producto.IdEstadoSubasta == 3)
               {
                  //En caso de que el producto haya sido vendido, se llama al método NotificarGanador el cual envia un email al ganador de la subasta
                  NotificarGanador(oferta, producto, _ContextoSubasta);
                  producto.Notificado = true;
                  producto.IdUsuarioComprador = oferta.IdUsuario;
                  _ContextoSubasta.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                  _ContextoSubasta.SaveChanges();
               }
               else if (producto.IdEstadoSubasta == 5)
               {
                  //En caso de que el producto NO haya sido vendido, se llama al método NotificarVendedor el cual envia un email al vendedor del producto
                  NotificarVendedor(oferta, producto, _ContextoSubasta);
                  producto.Notificado = true;
                  _ContextoSubasta.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                  _ContextoSubasta.SaveChanges();
               }

            }
         }
      }
      public void NotificarGanador(Oferta datos, SubastaProducto producto, ContextoSubasta _ContextoSubasta)
      {
         Mail email = new Mail();
         var usuario = _ContextoSubasta.Usuario.Where(x => x.IdUsuario == datos.IdUsuario).FirstOrDefault();
         Usuario usuarioGanador = usuario;
         email.EmailDestino = usuarioGanador.Email;
         email.AsuntoEmail = "¡Felicidades! Ha ganado la subasta de su producto:";
         email.enviar(String.Format("Hola <b>{0} {1}</b>, tenemos el agrado de informarle que fué ganador del remate del producto  <b>{2}</b>, por lo que a la brevedad el vendedor se contactará con usted. ¡Felicidades! </br></br>Atte: El equipo de TUPsubastas", usuarioGanador.Nombre, usuarioGanador.Apellido, producto.NombreProducto));

         var usuarioVendedor = _ContextoSubasta.Usuario.Where(x => x.IdUsuario == producto.IdUsuario).FirstOrDefault();        
         email.EmailDestino = usuarioVendedor.Email;
         email.AsuntoEmail = "¡Felicidades! Su producto ha sido subastado:";
         email.enviar(String.Format("Hola <b>{0} {1}</b>, tenemos el agrado de informarle que su producto <b>{2}</b> ha sido subastado exitosamente. El usuario <b>{3}</b> queda al aguardo de que se contacte con él a su email <b>{4}</b>. Saludos! </br></br>Atte: El equipo de TUPsubastas", usuarioVendedor.Nombre, usuarioVendedor.Apellido, producto.NombreProducto, usuarioGanador.Nombre+" "+usuarioGanador.Apellido, usuarioGanador.Email));


      }
      public void NotificarVendedor(Oferta datos, SubastaProducto producto, ContextoSubasta _ContextoSubasta)
      {
         Mail email = new Mail();
         var usuario = _ContextoSubasta.Usuario.Where(x => x.IdUsuario == producto.IdUsuario).FirstOrDefault();
         Usuario usuarioVendedor = usuario;
         email.EmailDestino = usuarioVendedor.Email;
         email.AsuntoEmail = "Su producto no fue subastado.";
         email.enviar(String.Format("Hola <b>{0} {1}</b>, le informamos que su producto  <b>{2}</b> no ha recibido ofertas. No obstante, lo invitamos a participar en la próxima subasta.", usuarioVendedor.Nombre, usuarioVendedor.Apellido, producto.NombreProducto));

      }


   }


}
