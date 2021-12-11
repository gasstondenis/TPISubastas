using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.Sitio.Models;
using TPISubastas.AccesoDatos;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace TPISubastas.Sitio.Controllers
{
    public class SubastaAjaxController : Controller
    {
        private readonly ContextoSubasta _contexto;
        private readonly UserManager<Security.SecurityUser> _UserManager;
        public SubastaAjaxController(ContextoSubasta contexto, UserManager<Security.SecurityUser> userManager)
        {
            _contexto = contexto;
            _UserManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ListarSubastas(int Pagina = 1, int Cantidad = 4)
        {
            if (Pagina < 1)
            {
                Pagina = 1;
            }
            if (Cantidad > 10)
            {
                Cantidad = 4;
            }
            if (Cantidad < 1)
            {
                Cantidad = 1;
            }
            SubastaListado listado = new SubastaListado();
            var ahora = DateTime.Now;
            var consulta = _contexto.Subasta.Where(x => x.Habilitada && x.FechaCierre > ahora && x.FechaInicio < ahora);
            int totalelementos = consulta.Count();
            listado.Subastas = consulta.Skip((Pagina - 1) * Cantidad).Take(Cantidad).Select(x => new SubastaItem(x)).ToList();
            listado.TotalPaginas = (totalelementos / Cantidad) + 1;
            listado.Cantidad = Cantidad;
            listado.Pagina = Pagina;
            return Json(listado);
        }
    }
}
