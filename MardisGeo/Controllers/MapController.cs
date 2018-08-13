using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MardisGeo.bussiness.Mapa;
using GeoMardis.Model.Mapa;
using MardisGeo.bussiness.Cuenta;

namespace MardisGeo.Controllers
{
  
    public class MapController : Controller
    {
        private string ValUsuario = null;
        private BAccount account = new BAccount();

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
        public ActionResult Index2()
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
        public IActionResult UE()
        {

        ValUsuario = HttpContext.Session.GetString("IsUsuario");

                if (ValUsuario != null)
                {

                    ids = int.Parse(HttpContext.Session.GetInt32("Isid").ToString());
                    var sltmap = maps.GetMap(ids);
                    ViewBag.sltmaps = sltmap;

                    ViewBag.lgnUsuario = ValUsuario;
                var a = account.GetUE().OrderBy(x =>x.Codigo);
                return View(a);
           
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
        public ActionResult dashboard(int id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {
                ids = int.Parse(HttpContext.Session.GetInt32("Isid").ToString());
                var sltmap = maps.GetMap(ids);
                ViewBag.sltmaps = sltmap;
                ViewData["IdRegister"] = id.ToString();
                ViewBag.lgnUsuario = ValUsuario;
                return View();
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }

        [HttpPost]
        public JsonResult GetDashBord(string iddash)
        {

            //var id = _protectorCampaign.Unprotect(idCampaign);
            //var url = _campaignBusiness.GetDashOne(Guid.Parse(id)).url;

            //var client = new RestClient("http://geomardis6728.cloudapp.net:8000/api/3.0/auth/signin");
            //var request = new RestRequest(Method.POST);

            //request.AddParameter("", "<tsRequest>\n  <credentials name=\"administrador\" password=\"M@rdisserver2018\" >\n    <site contentUrl=\"topsy\" />\n  </credentials>\n</tsRequest>", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //  var responseBody = Json(response.RawBytes.ToString());
            //string result = System.Text.Encoding.UTF8.GetString(response.RawBytes);

            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var sltmap = maps.Getdashboard(int.Parse(iddash)).ToList();

                var jsondata = sltmap.ToArray();
                return Json(jsondata);

            }
            else
            {
                return Json("");

            }
       
        }
        #endregion;
        // GET: Map/Create

        public ActionResult Dashbord_Superior()
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
        public ActionResult Dashbord_UE()
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
        public ActionResult Dashbord_holcim()
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

        public ActionResult Dashbord_Spr()
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

        public ActionResult Dashbord_Spr_gya()
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

        public ActionResult Dashbord_store()
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


        public ActionResult Dashbord_Papelesa()
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
        public ActionResult Dashbord_Spr_UIO_panaderia()
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

        public ActionResult UEAvance()
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
    }


}