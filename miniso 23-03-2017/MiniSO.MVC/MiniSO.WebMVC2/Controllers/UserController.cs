using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniSO.WebMVC2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult NewUser()
        {
            return PartialView();
        }

        public ActionResult RegisterQuestion()
        {
            return PartialView();
        }

        public ActionResult GetQuestion()
        {
            return PartialView();
        }

    }
}