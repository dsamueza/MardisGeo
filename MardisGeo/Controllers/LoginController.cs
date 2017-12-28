using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoMardis.Model.Login;
using MardisGeo.bussiness.Login;
using GeoMardis.Model.Mapa;
using MardisGeo.bussiness.Mapa;
using Microsoft.AspNetCore.Http;
namespace MardisGeo.Controllers
{
    
    public class LoginController : Controller
    {
        private UsuarioValido usuario = new UsuarioValido();
        private MapaGenerador map = new MapaGenerador();
        const string SessionKeyName = "_Name";
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "login");
          
        }

        
        [HttpPost]
        public ActionResult Index(login ModelLogin)
        {
            if (ModelState.IsValid)
            {
                var loginUsuario = usuario.IsUsuario(ModelLogin.NombreUsuario, ModelLogin.PassUsuario);
                if (loginUsuario != null) { 
                if (loginUsuario.First().Tipo == 1) {
                    ViewBag.lgnUsuario = loginUsuario;
                    HttpContext.Session.SetString("IsUsuario", loginUsuario.First().NombreUsuario);
                    HttpContext.Session.SetInt32("Isid", loginUsuario.First().Id);
                        return RedirectToAction("Index", "Admin");
                }
                if (loginUsuario.First().Tipo == 2)
                {
                    ViewBag.lgnUsuario = loginUsuario;
                    HttpContext.Session.SetString("IsUsuario", loginUsuario.First().NombreUsuario);
                        HttpContext.Session.SetInt32("Isid", loginUsuario.First().Id);
                        return RedirectToAction("Index", "Visualizador");
                }
                if (loginUsuario.First().Tipo == 3)
                {
                    ViewBag.lgnUsuario = loginUsuario;
                    
                  //  ViewData.Model = sltmap;
                    HttpContext.Session.SetString("IsUsuario", loginUsuario.First().NombreUsuario);
                    HttpContext.Session.SetInt32("Isid", loginUsuario.First().Id);
                    return RedirectToAction("Map", "Map");
                }
                }

            }
            ViewBag.msg = "El Usuario o la contraseña no son correctos.";


            return View();


        }
        public JsonResult UpdatePass(string newpass)
        {
          string  ValUsuario = HttpContext.Session.GetString("IsUsuario");
            if (ValUsuario != null)
            {
               int ids = int.Parse(HttpContext.Session.GetInt32("Isid").ToString());
             var   jsondata= usuario.UpdatePass(newpass, ids);
                return Json(jsondata);
            }
            else
            {
                return Json("");

            }

        }

    }

    }
