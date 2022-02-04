using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TPISubastas.AccesoDatos;
using TPISubastas.Dominio;

namespace TPISubastas.Sitio.HostedServices
{
   public class EstadoSubastaHostedService : IHostedService, IDisposable
   {
      //Este servicio setea los estados de los productos de subastas cerradas en Vendido y NoVendido

      private IServiceScopeFactory _ScopeFactory;
      private Timer _timer;


      public EstadoSubastaHostedService(IServiceScopeFactory scopeFactory)
      {
         _ScopeFactory = scopeFactory;
      }

      public Task StartAsync(CancellationToken cancellationToken)
      {
         _timer = new Timer(DefinirEstadoSubasta, null, TimeSpan.FromSeconds(30), TimeSpan.FromMinutes(1));
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

      public void DefinirEstadoSubasta(object state)
      {
         using (var scope = _ScopeFactory.CreateScope())
         {
            var _ContextoSubasta = scope.ServiceProvider.GetRequiredService<ContextoSubasta>();

            var subastas = _ContextoSubasta.Subasta.Where(x => x.FechaCierre <= DateTime.Now || !x.Habilitada).Select(x => x.IdSubasta).ToList();
            var productos = _ContextoSubasta.SubastaProducto.Where(x => !x.Notificado && subastas.Contains(x.IdSubasta)).ToList();
            SubastaProducto producto = new SubastaProducto();
            foreach (var item2 in productos)
            {
               producto = item2;
               var oferta = _ContextoSubasta.Oferta.Where(x => x.IdSubastaProducto == producto.IdSubastaProducto).OrderByDescending(x => x.Monto).FirstOrDefault();

               if (oferta != null)
               {
                  item2.IdEstadoSubasta = 3;
                  item2.OfertaFinal = oferta.Monto;
                  _ContextoSubasta.Entry(item2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                  _ContextoSubasta.SaveChanges();
               }
               else
               {
                  item2.IdEstadoSubasta = 5;                  
                  _ContextoSubasta.Entry(item2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                  _ContextoSubasta.SaveChanges();
               }

            }
         }
      }

   }


}
