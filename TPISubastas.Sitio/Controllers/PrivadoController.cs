using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPISubastas.Sitio.Controllers
{   
    [Authorize]
    public class PrivadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
