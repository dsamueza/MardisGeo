using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MardisGeo.Views.modelWeb;
using GeoMardis.Model.Categorias;
using MardisGeo.bussiness.Categoria;
using Microsoft.AspNetCore.Mvc.Rendering;
using MardisGeo.bussiness.Secuencia;
using MardisGeo.bussiness.Geo;
using System.Text;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.DotNet.PlatformAbstractions;

namespace MardisGeo.Controllers
{
    public class VisualizadorController : Controller
    {

        private string ValUsuario=null;
        private ICategoria categoria = new ICategoria();
        private Secuencial secuencial = new Secuencial();
        private Geofoto foto = new Geofoto();
        private SaveGeoUbicacion geoUbicacion = new SaveGeoUbicacion();
        // GET: Visualizador
        public ActionResult Index()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
         
            if (ValUsuario != null)
            {

                IList<ListModel> lstCategoria = new List<ListModel>();
                IList<geo_categoria> structCategoria = new List<geo_categoria>();
              
                var strucCategoria = categoria.CategoriasActivas();
                var d = (from x in strucCategoria
                               select new { Id = x.id, Text = x.Name});
                SelectList slCategoria = new SelectList(d, "Id", "Text");
                ViewBag.slCategoria = slCategoria;
              
                
                    ViewBag.lgnUsuario = ValUsuario;
                return View();
            }
            else {
                return RedirectToAction("logout", "Login");

            }
            
        }

        // GET: Visualizador/Details/5
       [HttpGet]
        public IActionResult Categoria()
        {

            IList<ListModel> lstCategoria = new List<ListModel>();
            IList<geo_categoria> structCategoria = new List<geo_categoria>();
            var strucCategoria= categoria.CategoriasActivas();
            SelectList slCategoria = new SelectList(lstCategoria, "Id", "Text");
            ViewBag.slCategoria = slCategoria;

            return View();
        }

        // POST: Visualizador/Create

        [HttpPost]
        public JsonResult Create(int selectcategoria )
        {
            int  cat =secuencial.NumberSecuencial();

            IList<ListModel> lstCategoria = new List<ListModel>();
            var stfoto = foto.Getfoto(selectcategoria);

            if (stfoto != null) { 
              var lstgrupofoto = (from x in stfoto
                                  select new { id = x.id, Text =  x.url  , sec= cat });
                return Json(lstgrupofoto.ToArray());
            }
            return Json(null);
        }

        

        // GET: Visualizador/Edit/5
        [HttpPost]
        public ActionResult Update(int selectcategoria)
        {

            IList<ListModel> lstCategoria = new List<ListModel>();
            var stfoto = foto.Getfoto(selectcategoria);
     
            if (stfoto != null)
            {
                var lstgrupofoto = (from x in stfoto
                                    select new { id = x.id, Text = x.url});
                return Json(lstgrupofoto.ToArray());
            }
            return Json(null);
        }

      

        // GET: Visualizador/Delete/5
        public ActionResult _StreetView()
        {
            return View();
        }
        private IHostingEnvironment _Env;
        public VisualizadorController(IHostingEnvironment envrnmt)
        {
            _Env = envrnmt;
        }
        // GET: Visualizador/Edit/5
        [HttpPost]
        public ActionResult Save(int selectcategoria , int secuencial, int idimagen , string heading, string coordenadas , string pitch)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {
                DateTime localDate = DateTime.Now;
            geo_ubicacion geo = new geo_ubicacion();
            geo.geo_ubu_des ="ingreso";
            geo.id_img = idimagen;
            geo.id_sec = secuencial;
            geo.create_date = localDate;
            geo.create_usr = HttpContext.Session.GetString("IsUsuario");
            var webRootInfo = _Env.WebRootPath+"\\images\\"+ selectcategoria+"\\";
        
            var url = "https://maps.googleapis.com/maps/api/streetview?size=900x800&location="+coordenadas.Replace("(","").Replace(")", "") + "&heading="+heading + "&pitch=" + pitch + "&key=AIzaSyBNY6hecKQkIFeckd2pfUKk6zyE921VakM";
      
            var success=  geoUbicacion.Save(geo.geo_ubu_des, geo.id_img, geo.id_sec, Convert.ToDateTime(geo.create_date), geo.create_usr,  url);
            if (success == 1) {
                    return Json(1);
                }

            return Json(null);
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }
    }
}