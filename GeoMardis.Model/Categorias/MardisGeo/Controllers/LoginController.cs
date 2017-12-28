using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoMardis.Model.Login;
using MardisGeo.bussiness.Login;
using Microsoft.AspNetCore.Http;
namespace MardisGeo.Controllers
{
    
    public class LoginController : Controller
    {
        private UsuarioValido usuario = new UsuarioValido();
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
                string loginUsuario = usuario.IsUsuario(ModelLogin.NombreUsuario, ModelLogin.PassUsuario);
                if (loginUsuario != null) {
                    ViewBag.lgnUsuario = loginUsuario;
                    HttpContext.Session.SetString("IsUsuario", loginUsuario);
                    return RedirectToAction("Index", "Visualizador");
                }
            }
             
              
            return View();


        }
          
        }

    }
