using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.AccesoDatos;
using TPISubastas.Dominio;

namespace TPISubastas.Sitio.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   public class SubastaProductoAPIController : ControllerBase
   {
      private readonly ContextoSubasta _contexto;

      public SubastaProductoAPIController(ContextoSubasta context)
      {
         _contexto = context;
      }

      // GET: api/<SubastaProductoAPIController>
      [HttpGet]
      public IEnumerable<SubastaProducto> Get()
      {
         return _contexto.SubastaProducto.ToList();
      }
      [HttpPost]
      public void Post([FromBody] SubastaProducto value)
      {
         _contexto.SubastaProducto.Add(value);
         _contexto.SaveChanges();
      }

      // GET api/<SubastaProductoAPIController>/5
      [HttpGet("{id}")]
      public SubastaProducto Get(int id)
      {
         return _contexto.SubastaProducto.FirstOrDefault(x => x.IdSubastaProducto == id);
      }

      // PUT api/<SubastaProductoAPIController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] SubastaProducto value)
      {
         var original = _contexto.SubastaProducto.FirstOrDefault(x => x.IdSubastaProducto == id);
         if (original != null)
         {
            original.IdSubasta = value.IdSubasta;
            original.NombreProducto = value.NombreProducto;
            original.MarcaProducto = value.MarcaProducto;
            original.DescripcionProducto = value.DescripcionProducto;
            original.ImagenProducto = value.ImagenProducto;
            original.FormaPago = value.FormaPago;
            original.MontoInicial = value.MontoInicial;
            original.IdUsuario = value.IdUsuario;
            original.IdUsuarioComprador = value.IdUsuarioComprador;
            original.IdProducto = value.IdProducto;
            original.IdEstadoSubasta = value.IdEstadoSubasta;
            original.Notificado = value.Notificado;


            _contexto.Entry(original).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
         }
      }
      // DELETE api/<SubastaProductoAPIController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
         var original = _contexto.SubastaProducto.FirstOrDefault(x => x.IdSubastaProducto == id);

         if (original != null)
         {
            _contexto.Entry(original).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _contexto.SaveChanges();
         }
      }
   }
}
