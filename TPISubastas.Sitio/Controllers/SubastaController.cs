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

        public IActionResult Index()
        {
            return View();
        }

        private void CargarSubastasDisponibles(SubastaProductoFormulario modelo)
        {
            modelo.SubastasDisponibles = new List<SelectListItem>();          
            var subastas = _contexto.Subasta.Where(s => s.Habilitada && s.FechaInicio > DateTime.Now).Select(s => new SelectListItem() { Text = s.Nombre, Value = s.IdSubasta.ToString() });
            modelo.SubastasDisponibles.AddRange(subastas);
        }
        private void CargarFormaPago(SubastaProductoFormulario modelo)
        {
            modelo.OpcionesPago = new List<SelectListItem>();
            modelo.OpcionesPago.Add(new SelectListItem() { Text = "Tarjeta de débito", Value = "1" });
            modelo.OpcionesPago.Add(new SelectListItem() { Text = "Tarjeta de crédito", Value = "2" });
            
        }

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
                var pagoSeleccionado = modelo.OpcionesPago.Where(o => o.Selected);
                nuevo.FormaPago = pagoSeleccionado.ToString();

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


    }
}
