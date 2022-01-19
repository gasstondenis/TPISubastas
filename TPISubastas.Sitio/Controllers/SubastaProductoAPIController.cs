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

       
    }
}
