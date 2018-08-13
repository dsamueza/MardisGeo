using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoMardis.Model.Admin;
using GeoMardis.Model.Perfil;
using Microsoft.AspNetCore.Mvc.Rendering;
using MardisGeo.bussiness.Login;
using MardisGeo.bussiness.Mapa;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MardisGeo.bussiness.Cuenta;
using MardisGeo.bussiness.Perfil;
using AutoMapper;

namespace MardisGeo.Controllers
{
    public class AdminController : Controller
    {
        private string ValUsuario = null;
        private UsuarioValido userv = new UsuarioValido();
        private BAccount account = new BAccount();
        private BProfile profile = new BProfile();
        private BMapas bmapas = new BMapas();
       
        // GET: Admin
        private readonly ILogger<HomeController> _logger;

        public AdminController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                ViewBag.lgnUsuario = ValUsuario;

                _logger.LogInformation("Index page says hello");
                return View();
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }


        public JsonResult _UserTable(int Id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var slttipo = userv.AllTypeUser();
                var rows = from x in userv.AllUser()
                           select new { id = x.id,
                               Nombre = x.NombreUsuario,
                               Login = x.LoginUsuario,
                               fecha = x.FechaUsuario,
                               Tipo = slttipo.Where(y => y.id == x.TipoUsuario).First().tipo,
                               Accion = "", update = "", delete = "" };
                var jsondata = rows.ToArray();
                return Json(jsondata);
            }
            else
            {
                return Json("");

            }

        }
        public JsonResult _UserTableUE(int Id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var slttipo = userv.AllTypeUser();
                var rows = account.GetUE();
                var jsondata = rows.ToArray();
                return Json(jsondata);
            }
            else
            {
                return Json("");

            }

        }
        public ActionResult AdmMap()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                DateTime localDate = DateTime.Now;
                ViewBag.lgnUsuario = ValUsuario;
                ViewBag.fecha = localDate;


                var model = TempData["mapmodel"];
                if (model == null) {

                    return View();
                }
                model = JsonConvert.DeserializeObject<ModelMap>(TempData["mapmodel"].ToString());
                ViewBag.fecha = JsonConvert.DeserializeObject<ModelMap>(TempData["mapmodel"].ToString()).FechaUsuario;
                TempData["mapmodel"] = null;
                ViewBag.lgnUsuario = ValUsuario;
                return View(model);
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }

        }
        [HttpPost]
        public ActionResult AdmMap(ModelMap Model)
        {

            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {
                typeUserView();
                if (ModelState.IsValid)
                {
                    Model.Usuario = ValUsuario;
                    bmapas.SaveMap(Model);
                    ModelState.Clear();
                    ViewBag.lgnUsuario = ValUsuario;
                    return View();
                }

            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
            return View(Model);

        }
        public JsonResult _MapTable(int Id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {

                var rows = from x in bmapas.AllMap()
                           select new { id = x.id,
                               Nombre = x.Name,
                               Descripcion = x.Description,
                               Link = x.Link,
                               fecha = x.FechaUsuario,
                               Estado = x.estado, Accion = "", update = "", delete = "" };
                var jsondata = rows.ToArray();
                return Json(jsondata);
            }
            else
            {
                return Json("");

            }

        }
        public ActionResult DeleteMap(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                if (bmapas.RemoveMap(int.Parse(ids)) != 1) {
                }
                return RedirectToAction("AdmMap");
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
    
        
        public IActionResult selectMap(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {


                var mMap = bmapas.GetMapSig(int.Parse(ids));

                TempData["mapmodel"] = JsonConvert.SerializeObject(mMap);


                return RedirectToAction("AdmMap", "Admin");


            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
        #region usuario
        public ActionResult User()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");



            if (ValUsuario != null)
            {
                var model = TempData["mapmodelUser"];
                if (model == null)
                {
                    typeUserView();
                    ViewBag.lgnUsuario = ValUsuario;
                    return View();
                }
                model = JsonConvert.DeserializeObject<GeoMardis.Model.Admin.Usuario>(TempData["mapmodelUser"].ToString());
                ViewBag.fecha = JsonConvert.DeserializeObject<GeoMardis.Model.Admin.Usuario>(TempData["mapmodelUser"].ToString()).FechaUsuario;
                int idtipo = JsonConvert.DeserializeObject<GeoMardis.Model.Admin.Usuario>(TempData["mapmodelUser"].ToString()).TipoUsuario;
                var slttipo = from t in userv.AllTypeUser()
                              where (t.id == idtipo)
                              select (new { Text = t.id, Value = t.tipo });
                var slttipo2 = from t in userv.AllTypeUser()
                               where (t.id != idtipo)
                               select (new { Text = t.id, Value = t.tipo });
                var Elevations = slttipo.Union(slttipo2)
                     .ToList();
                ViewBag.lgnUsuario = ValUsuario;
                ViewBag.TimeZoneList = new SelectList(Elevations, "Text", "Value");
                TempData["mapmodelUser"] = null;
                return View(model);
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
        [HttpPost]
        public ActionResult User(Usuario MUsuario)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {
                MUsuario.FechaUsuario = "";
                ViewBag.lgnUsuario = ValUsuario;
                typeUserView();
                if (ModelState.IsValid)
                {
                   
                    userv.SaveUser(MUsuario);
                    ModelState.Clear();
                   
                    return View();
                }

            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
            return View(MUsuario);
        }
        public void typeUserView()
        {
            var slttipo = from t in userv.AllTypeUser()
                          select (new { Text = t.id, Value = t.tipo });
            ViewBag.TimeZoneList = new SelectList(slttipo, "Text", "Value");
            DateTime localDate = DateTime.Now;
            ViewBag.lgnUsuario = ValUsuario;
            ViewBag.fecha = localDate;


        }
    
        public ActionResult DeleteUser(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                if (userv.RemoveUser(int.Parse(ids)) != 1)
                {
                }
                return RedirectToAction("user");
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
        public IActionResult selectUser(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {


                var users = userv.GetUserSig(int.Parse(ids));

                TempData["mapmodelUser"] = JsonConvert.SerializeObject(users);


                return RedirectToAction("User", "Admin");


            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
        #endregion

        #region Account
        [HttpPost]
        public JsonResult Account( int id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var vaccount = account.GetAccount();
                var rows = from x in vaccount
                           select new
                           {
                               idaccount = x.Id,
                               account = x.Nombre
                             
                           };
                var jsondata = rows.ToArray();
                return Json(jsondata);
            }
            else
            {
                return Json("");

            }

        }
        [HttpPost]
        public JsonResult ProfileDash(int id, int idper)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var vaperson = profile.GetPerfilDash(idper);
                var vaccount = profile.GetPerfilAccountMap(id);


                var rows = from x in vaccount
                           select new
                           {
                               idaccount = x.Id,
                               account = x.nombre,
                               person = ProfileMDash(x.Id, vaperson)
                           };
                var jsondata = rows.ToArray();
                return Json(jsondata);




            }
            else
            {
                return Json("");

            }
        }

        public int ProfileMDash(int id, IList<MProfileMap> m)
        {

            try
            {
                var user = m.Where(x => x.Idprofile == id).First().Iddash;
                return user;
            }
            catch (Exception)
            {

                return 0;
            }


        }
        #endregion

        #region Profile
        [HttpPost]
        public JsonResult Profile(int id, int idper)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var vaperson = profile.GetPerfilPerson(idper);
                var vaccount = profile.GetPerfilAccount(id);
                
             
                    var rows = from x in vaccount
                               select new
                               {
                                   idaccount = x.Id,
                                   account = x.nombre,
                                   person = Profile(x.Id,vaperson)
                               };
                    var jsondata = rows.ToArray();
                    return Json(jsondata);
               
               
              
             
            }
            else
            {
                return Json("");

            }

        }

    public  int Profile(int id, IList<MProfilePerson> m) {

            try
            {
                var user = m.Where(x => x.Idprofile == id).First().iduser;
                return user;
            }
            catch (Exception)
            {

                return 0;
            }

          
        }
        public JsonResult saveprofile(int id, int idper)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {
          
                MProfilePerson profileperson = new MProfilePerson {Idprofile= id,iduser= idper,status="A",geo_usr_profile1="A",geo_map_usr= ValUsuario };
                profile.AddRemovePerfilPerson(profileperson);

               
                return Json("");




            }
            else
            {
                return Json("");

            }

        }

        #endregion
        #region Map
        [HttpPost]
        public JsonResult ProfileMap(int id, int idper)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var vaperson = profile.GetPerfilMap(idper);
                var vaccount = profile.GetPerfilAccountMap(id);


                var rows = from x in vaccount
                           select new
                           {
                               idaccount = x.Id,
                               account = x.nombre,
                               person = ProfileMap(x.Id, vaperson)
                           };
                var jsondata = rows.ToArray();
                return Json(jsondata);




            }
            else
            {
                return Json("");

            }

        }

        public int ProfileMap(int id, IList<MProfileMap> m)
        {

            try
            {
                var user = m.Where(x => x.Idprofile == id).First().idmap;
                return user;
            }
            catch (Exception)
            {

                return 0;
            }


        }
        public JsonResult saveprofileMap(int id, int idper)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                MProfileMap profilemap = new MProfileMap { Idprofile = id, idmap = idper, status = "A", geo_map_usr = ValUsuario ,descripcion="Mapa nuevo" };
                profile.AddRemovePerfilMap(profilemap);


                return Json("");




            }
            else
            {
                return Json("");

            }

        }

        #endregion

        public IActionResult UE() {


            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {


          
           

                var a = account.GetUE();
                return View(a);


            }
            else
            {
                return RedirectToAction("logout", "Login");

            }

           
        }

        public IActionResult Superior()
        {


            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {





                var a = account.GetUE();
                return View(a);


            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }

        public IActionResult UEL()
        {
            var a = account.GetUE();
            return View(a);
        }
        #region Dashboard

        public ActionResult AdmDash()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                DateTime localDate = DateTime.Now;
                ViewBag.lgnUsuario = ValUsuario;
                ViewBag.fecha = localDate;


                var model = TempData["mapmodeldash"];
                if (model == null)
                {

                    return View();
                }
                model = JsonConvert.DeserializeObject<DashboardModelRegister>(TempData["mapmodeldash"].ToString());
                ViewBag.fecha = JsonConvert.DeserializeObject<DashboardModelRegister>(TempData["mapmodeldash"].ToString()).FechaUsuario;
                TempData["mapmodeldash"] = null;
                ViewBag.lgnUsuario = ValUsuario;
                return View(model);
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }

        }
        [HttpPost]
        public ActionResult AdmDash(DashboardModelRegister Model)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {
                typeUserView();
                if (ModelState.IsValid)
                {
                    Model.Usuario = ValUsuario;
                    bmapas.SaveDashBoard(Model);

                    ModelState.Clear();
                    ViewBag.lgnUsuario = ValUsuario;
                    return View();
                }

            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
            return View(Model);
        }
        public ActionResult DeleteDash(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                if (bmapas.RemoveDash(int.Parse(ids)) != 1)
                {
                }
                return RedirectToAction("AdmDash");
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
        public JsonResult _MapTableDash(int Id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {

                var rows = from x in bmapas.AllDashboard()
                           select new
                           {
                               id = x.id,
                               Nombre = x.Name,
                               Descripcion = x.Description,
                               Link = x.Link,
                               fecha = x.FechaUsuario,
                               Estado = x.estado,
                               Linkmobil = x.LinkModel,
                               Accion = "",
                               update = "",
                               delete = ""

                           };
                var jsondata = rows.ToArray();
                return Json(jsondata);
            }
            else
            {
                return Json("");

            }

        }

        public IActionResult selectDash(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {


                var mMap = bmapas.GetDashboaarSig(int.Parse(ids));

                TempData["mapmodeldash"] = JsonConvert.SerializeObject(mMap);


                return RedirectToAction("AdmDash", "Admin");


            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
        public JsonResult saveprofileDashBoard(int id, int idper)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                MProfileMap profilemap = new MProfileMap { Idprofile = id, Iddash = idper, status = "A", geo_map_usr = ValUsuario, descripcion = "Mapa nuevo" };
                profile.AddRemovePerfildash(profilemap);


                return Json("");




            }
            else
            {
                return Json("");

            }

        }

        #endregion
    }
}