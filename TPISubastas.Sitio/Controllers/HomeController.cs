using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.Sitio.Models;
using TPISubastas.Sitio.Controllers;
using TPISubastas.AccesoDatos;

namespace TPISubastas.Sitio.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly ContextoSubasta _contexto;

      public HomeController(ILogger<HomeController> logger, ContextoSubasta contexto)
      {
         _logger = logger;
         _contexto = contexto;
      }

      public IActionResult Index(int Pagina = 1, int Cantidad = 6)
      {
         if (Pagina < 1)
         {
            Pagina = 1;
         }
         if (Cantidad > 10)
         {
            Cantidad = 6;
         }
         if (Cantidad < 1)
         {
            Cantidad = 1;
         }
         SubastaListado listado = new SubastaListado();
         var ahora = DateTime.Now;
         var consulta = _contexto.Subasta.Where(x => x.Habilitada && x.FechaCierre > DateTime.Now);
        
         int totalelementos = consulta.Count();
         listado.Subastas = consulta.Skip((Pagina - 1) * Cantidad).Take(Cantidad).Select(x => new SubastaItem(x)).ToList();
         listado.FuturasSubastas = consulta.Select(x => new SubastaItem(x)).ToList();
         listado.TotalPaginas = (totalelementos / Cantidad) + 1;
         listado.Cantidad = Cantidad;
         listado.Pagina = Pagina;
         return View(listado);

      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
      [HttpGet]

      public IActionResult About()
      {
         return View();
      }

   }
}
