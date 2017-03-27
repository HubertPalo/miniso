using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniSO.Servicio;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace MiniSO.MVC.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IServicioMiniSO servicio;

        public HomeController(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }
        /*
        public ActionResult Login(string username, string password)
        {
            if (servicio.IsValid(username, password))
            {
                var ident = new ClaimsIdentity( new[] {
                    // adding following 2 claim just for supporting default antiforgery provider
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                    new Claim(ClaimTypes.Name,username),

                    // optionally you could add roles if any
                    new Claim(ClaimTypes.Role, "RoleName"),
                    new Claim(ClaimTypes.Role, "AnotherRole"),
                }, DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.GetOwinContext().Authentication.SignIn(
                   new AuthenticationProperties { IsPersistent = false }, ident);
                return RedirectToAction("MyAction"); // auth succeed 
            }
            // invalid username or password
            ModelState.AddModelError("", "invalid username or password");
            return View();
        }*/

    }
}