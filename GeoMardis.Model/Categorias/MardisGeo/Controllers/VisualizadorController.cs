using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MardisGeo.Controllers
{
    public class VisualizadorController : Controller
    {

        private string ValUsuario=null;

        // GET: Visualizador
        public ActionResult Index()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
         
            if (ValUsuario != null)
            {
                ViewBag.lgnUsuario = ValUsuario;
                return View();
            }
            else {
                return RedirectToAction("logout", "Login");

            }
            
        }

        // GET: Visualizador/Details/5
        public ActionResult Categoria()
        {
            return View();
        }

        // GET: Visualizador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visualizador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visualizador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Visualizador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visualizador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Visualizador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}