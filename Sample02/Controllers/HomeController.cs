using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    public class HomeController : Controller
    {
        #region [-ctor-]
        public HomeController()
        {

        } 
        #endregion

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}