using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {

        }
       
        public ActionResult Index()
        {
            return View();
        }
    }
}