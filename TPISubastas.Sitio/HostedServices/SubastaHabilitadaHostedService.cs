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
   public class SubastaHabilitadaHostedService : IHostedService, IDisposable
   {
      //Este servicio desactiva las subastas llegado su tiempo de cierre

      private IServiceScopeFactory _ScopeFactory;
      private Timer _timer;


      public SubastaHabilitadaHostedService(IServiceScopeFactory scopeFactory)
      {
         _ScopeFactory = scopeFactory;
      }

      public Task StartAsync(CancellationToken cancellationToken)
      {
         _timer = new Timer(SubastaHabilitada, null, TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(1));
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

      public void SubastaHabilitada(object state)
      {
         using (var scope = _ScopeFactory.CreateScope())
         {
            var _ContextoSubasta = scope.ServiceProvider.GetRequiredService<ContextoSubasta>();

            var subastas = _ContextoSubasta.Subasta.Where(x => x.FechaCierre <= DateTime.Now && x.Habilitada == true).ToList();

            Subasta subasta = new Subasta();
            foreach (var item2 in subastas)
            {
               subasta = item2;

               if (subasta != null)
               {
                  subasta.Habilitada = false;
                  _ContextoSubasta.Entry(subasta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                  _ContextoSubasta.SaveChanges();
               }

            }
         }
      }
   }
}
