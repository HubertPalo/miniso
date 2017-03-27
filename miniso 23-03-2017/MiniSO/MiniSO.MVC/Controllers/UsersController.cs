using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniSO.Servicio;
using System.Threading.Tasks;
using System.Security.Claims;
using MiniSO.Entidades;
using System.Net.Http;


namespace MiniSO.MVC.Controllers
{
    public class UsersController : Controller
    {
        protected readonly IServicioMiniSO servicio;
        public UsersController(IServicioMiniSO _servicio)
        {
            servicio = _servicio;
        }
        // GET: Users
        public ActionResult Index()
        {
            //ModelState.Clear();
            //return View(servicio.GetAllValidUsers());
            return View();
        }

        public ActionResult Create()
        {
            return View(servicio.GetEmptyUserView());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            /*
            try
            {
                // TODO: Add insert logic here
                if (Request.Form["UserPassword"].Equals(Request.Form["ConfirmPassword"]))
                {
                    servicio.AddUser(Request.Form["UserName"], Request.Form["UserEmail"], Request.Form["UserPassword"]);
                    return RedirectToAction("Index");
                }else
                {
                    ViewBag.Error = "Las contraseñas no son iguales";
                    return View();
                }
                
            }
            catch
            {
                return View();
            }*/

            /*
            using (var client = new HttpClient())
            {
                // Assuming the API is in the same web application. 
                client.BaseAddress = new Uri("http://localhost:52151/");
                int result = client.PostAsync("/api/post",
                                              userview,
                                              new JsonMediaTypeFormatter())
                                    .Result
                                    .Content
                                    .ReadAsAsync<int>()
                                    .Result;

                // add to viewmodel
                var model = new ViewModel
                {
                    intValue = result
                };

                return View(model);
            }*/

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(servicio.GetUserById(id));
        }

        public ActionResult Login()
        {
            return View(servicio.GetEmptyUserView());
        }
        [HttpPost]
        public ActionResult Login(UserView user)
        {
            if (ModelState.IsValid)
            {
                int result = servicio.GetId(user.UserName, user.UserPassword);
                if (result != -1)
                {
                    Session["UserID"] = result;
                    Session["UserName"] = user.UserName;
                    return RedirectToAction("Index");
                }
            }   
            // invalid username or password
            ModelState.AddModelError("", "invalid username or password");
            return View(servicio.GetEmptyUserView());
        }
    }
}