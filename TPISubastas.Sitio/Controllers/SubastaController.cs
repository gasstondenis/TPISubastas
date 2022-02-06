using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TPISubastas.AccesoDatos;
using Microsoft.AspNetCore.Identity;
using TPISubastas.Sitio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TPISubastas.Sitio.Controllers
{
   public class SubastaController : Controller
   {
      private readonly ContextoSubasta _contexto;
      private readonly UserManager<Security.SecurityUser> _UserManager;
      public SubastaController(ContextoSubasta contexto, UserManager<Security.SecurityUser> userManager)
      {
         _contexto = contexto;
         _UserManager = userManager;
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
         var consulta = _contexto.Subasta.Where(x => x.Habilitada && x.FechaCierre > DateTime.Now && x.FechaInicio < DateTime.Now);
         int totalelementos = consulta.Count();
         listado.Subastas = consulta.Skip((Pagina - 1) * Cantidad).Take(Cantidad).Select(fuente => new SubastaItem(fuente)).ToList();
         listado.TotalPaginas = (totalelementos / Cantidad) + 1;
         listado.Cantidad = Cantidad;
         listado.Pagina = Pagina;
         return View(listado);
      }

      private void CargarSubastasDisponibles(SubastaProductoFormulario modelo)
      {
         modelo.SubastasDisponibles = new List<SelectListItem>();
         var subastas = _contexto.Subasta.Where(s => s.Habilitada && s.FechaInicio > DateTime.Now.Date).Select(s => new SelectListItem() { Text = s.Nombre, Value = s.IdSubasta.ToString() });
         modelo.SubastasDisponibles.AddRange(subastas);
      }
      private void CargarFormaPago(SubastaProductoFormulario modelo)
      {


      }

      [Authorize]
      [HttpGet]
      public IActionResult Crear()
      {
         SubastaProductoFormulario modelo = new SubastaProductoFormulario();
         CargarSubastasDisponibles(modelo);
         CargarFormaPago(modelo);
         return View(modelo);
      }


      [HttpPost]
      public async Task<IActionResult> Crear(SubastaProductoFormulario modelo)
      {
         if (ModelState.IsValid)
         {
            TPISubastas.Dominio.SubastaProducto nuevo = new Dominio.SubastaProducto();
            nuevo.IdSubasta = modelo.IdSubasta;
            nuevo.IdEstadoSubasta = (int)TPISubastas.Dominio.Estados.Propuesto;
            nuevo.IdSubasta = modelo.IdSubasta;
            nuevo.ImagenProducto = modelo.ImagenProducto;
            nuevo.MarcaProducto = modelo.MarcaProducto;
            nuevo.MontoInicial = modelo.MontoInicial;
            nuevo.NombreProducto = modelo.NombreProducto;
            nuevo.DescripcionProducto = modelo.DescripcionProducto;
            nuevo.FormaPago = modelo.FormaPago;


            var usuario = await _UserManager.GetUserAsync(User);
            nuevo.IdUsuario = usuario.IdUsuarioSubasta.Value;
            _contexto.SubastaProducto.Add(nuevo);
            //_contexto.Entry(nuevo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _contexto.SaveChanges();
            return View("Exito");
         }
         else
         {
            CargarSubastasDisponibles(modelo);
         }
         return View(modelo);
      }

      public IActionResult DetalleSubasta(int IdSubasta, int Pagina = 1, int Cantidad = 6)
      {
         if (Pagina < 1)
         {
            Pagina = 1;
         }
         if (Cantidad > 10)
         {
            Cantidad = 3;
         }
         if (Cantidad < 1)
         {
            Cantidad = 1;
         }
         SubastaDetalle listado = new SubastaDetalle();
         var consulta = _contexto.SubastaProducto.Where(x => x.IdSubasta == IdSubasta && x.IdEstadoSubasta == (int)TPISubastas.Dominio.Estados.Aprobado).ToList();
         int totalelementos = consulta.Count();
         listado.Productos = consulta.Skip((Pagina - 1) * Cantidad).Take(Cantidad).ToList();
         listado.TotalPaginas = (totalelementos / Cantidad) + 1;
         listado.Cantidad = Cantidad;
         listado.Pagina = Pagina;
         listado.IdSubasta = IdSubasta;

         /*
                     var detalle = new ProductoListado();
                     detalle.Productos = _contexto.SubastaProducto.Where(x=> x.IdSubasta == IdSubasta /*&& x.IdEstadoSubasta ==  (int)TPISubastas.Dominio.Estados.Aprobado*//*).ToList();
                     int totalelementos = detalle.Productos.Count();
                     detalle.TotalPaginas = (totalelementos / Cantidad) + 1;
                     detalle = detalle.Productos.Skip((Pagina - 1) * Cantidad).Take(Cantidad).Select().ToList();
                     detalle.Cantidad = Cantidad;
                     detalle.Pagina = Pagina;
                     detalle.IdSubasta = IdSubasta;
                     */
         return View(listado);

      }

      [Authorize]
      [HttpGet]
      public IActionResult Oferta(int IdSubasta, int IdSubastaProducto)
      {
         var detalle = new SubastaDetalle();
         detalle.detalleProducto = _contexto.SubastaProducto.FirstOrDefault(x => x.IdSubasta == IdSubasta && x.IdSubastaProducto == IdSubastaProducto);
         detalle.ofertaRealizada = _contexto.Oferta.Where(x => x.IdSubasta == IdSubasta && x.IdSubastaProducto == IdSubastaProducto).OrderByDescending(x => x.Monto).Select(x => x.Monto).FirstOrDefault();

         return View(detalle);
      }

      [HttpPost]
      public async Task<IActionResult> Oferta(SubastaDetalle modelo)
      {
         if (modelo.detalleProducto != null && modelo.ofertaRealizada > 0 && modelo.detalleProducto.IdSubasta != 0 && modelo.detalleProducto.IdSubastaProducto != 0)
         {
            TPISubastas.Dominio.Oferta nuevo = new Dominio.Oferta();
            nuevo.IdSubasta = modelo.detalleProducto.IdSubasta;
            nuevo.IdSubastaProducto = modelo.detalleProducto.IdSubastaProducto;

            var usuario = await _UserManager.GetUserAsync(User);
            nuevo.IdUsuario = usuario.IdUsuarioSubasta.Value;
            nuevo.Fecha = DateTime.Now;
            nuevo.Monto = modelo.ofertaRealizada;

            _contexto.Oferta.Add(nuevo);
            _contexto.SaveChanges();
         }
         else
         {
            return View(modelo);
         }

         return View("OfertaExitosa", modelo);
      }


   }
}
