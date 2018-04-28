using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MardisGeo.bussiness.Mapa;
using GeoMardis.Model.Mapa;
namespace MardisGeo.Controllers
{
  
    public class MapController : Controller
    {
        private string ValUsuario = null;
        private Int32 ids = 0;
        private MapaGenerador maps = new MapaGenerador();
        // GET: Map
        public ActionResult Index()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                ViewBag.lgnUsuario = ValUsuario;
                return View();
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }

        public ActionResult Dashbord()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                ids = int.Parse(HttpContext.Session.GetInt32("Isid").ToString());
                var sltmap = maps.GetMap(ids);
                ViewBag.sltmaps = sltmap;

                ViewBag.lgnUsuario = ValUsuario;
                return View();
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }
        #region Logica de visualizacion Map
        public ActionResult Map()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                ids = int.Parse(HttpContext.Session.GetInt32("Isid").ToString());
                var sltmap = maps.GetMap(ids);
                ViewBag.sltmaps = sltmap;

                ViewBag.lgnUsuario = ValUsuario;
                return View();
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }
        // GET: Map/Details/5
        public ActionResult view(int id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {
                ids = int.Parse(HttpContext.Session.GetInt32("Isid").ToString());
                var sltmap = maps.GetMap(ids);
                ViewBag.sltmaps = sltmap;
                var mmap = sltmap.Where(x => x.Id == id.ToString());
                ModelMap mapm = new ModelMap();
                if (mmap.Count() > 0)
                {
                    mapm.geo_map_link = mmap.First().geo_map_link;

                    mapm.geo_map_name = mmap.First().geo_map_name;
                }
                else {
                    mapm.geo_map_name = "El mapa no se encuentra asignado al usuario";
                }

                ViewBag.lgnUsuario = ValUsuario;
                return View(mapm);
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }

        #endregion;
        // GET: Map/Create
      
       
    }
   
   

}