using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPISubastas.Sitio.Controllers
{
    public class SubastaMVCController : Controller
    {
        // GET: SubastaMVCController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubastaMVCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubastaMVCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubastaMVCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubastaMVCController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubastaMVCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubastaMVCController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubastaMVCController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
