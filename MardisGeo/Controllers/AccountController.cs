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
namespace MardisGeo.Controllers
{
    public class Account : Controller
    {
        private string ValUsuario = null;
        private UsuarioValido userv = new UsuarioValido();
        private BAccount account = new BAccount();
        private BProfile profile = new BProfile();
        private BMapas bmapas = new BMapas();

        // GET: Admin
    

    
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
        public ActionResult Save()
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

        public ActionResult Add()
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                ViewBag.lgnUsuario = ValUsuario;
                var model = TempData["mapmodelProfile"];
                if (model == null)
                {

                    AccountView();

                    return View();
                }
                model = JsonConvert.DeserializeObject<MProfile>(TempData["mapmodelProfile"].ToString());
                ViewBag.fecha = JsonConvert.DeserializeObject<MProfile>(TempData["mapmodelProfile"].ToString()).FechaUsuario;
                int idtipo = JsonConvert.DeserializeObject<MProfile>(TempData["mapmodelProfile"].ToString()).idaccount;

                
                var slttipo = from t in account.GetAccount()
                              where (t.Id == idtipo)
                              select (new { Text = t.Id, Value = t.Nombre });
                var slttipo2 = from t in account.GetAccount()
                               where (t.Id != idtipo)
                               select (new { Text = t.Id, Value = t.Nombre });
                var Elevations = slttipo.Union(slttipo2)
                     .ToList();
                ViewBag.lgnUsuario = ValUsuario;
                ViewBag.Account = new SelectList(Elevations, "Text", "Value");
                
                TempData["mapmodelUser"] = null;
                return View(model);
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Add(MProfile modelo)
        {
                ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {

                AccountView();
                profile.SaveProfile(modelo);
                ModelState.Clear();
                ViewBag.lgnUsuario = ValUsuario;

                return View();
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }
        }
        public void AccountView()
        {
            var slttipo = from t in account.GetAccount()
                          select (new { Text = t.Id, Value = t.Nombre});
            ViewBag.Account = new SelectList(slttipo, "Text", "Value");
            DateTime localDate = DateTime.Now;
            ViewBag.lgnUsuario = ValUsuario;
            ViewBag.fecha = localDate;


        }
        public JsonResult _ProfileTable(int Id)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                var slttipo = account.GetAccount();
                var rows = from x in profile.AllProfile()
                           select new
                           {
                               id = x.Id,
                               Nombre = x.nombre,
                             codigo=x.code,
                               fecha = x.FechaUsuario,
                               Estado = x.status,
                               cuenta= (from y in slttipo
                                        where (y.Id== x.idaccount)
                                        select y.Nombre ).Single(),
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
        public ActionResult DeleteProfile(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
                if (profile.RemoveProfile(int.Parse(ids)) != 1)
                {
                }
                return RedirectToAction("Add");
            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }
        public IActionResult selectProfile(string ids)
        {
            ValUsuario = HttpContext.Session.GetString("IsUsuario");

            if (ValUsuario != null)
            {


                var perfil = profile.GetPerfilSig(int.Parse(ids));

                TempData["mapmodelProfile"] = JsonConvert.SerializeObject(perfil);


                return RedirectToAction("Add", "Account");


            }
            else
            {
                return RedirectToAction("logout", "Login");

            }


        }



    }
}