using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample02.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public Sample02.Models.DomainModels.DTO.EF.OnlineShopEntities Ref_OnlineShopEntities { get; set; }
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            var Ref_OnlineShopEntities = new Models.DomainModels.DTO.EF.OnlineShopEntities();
            //Get the Products entities and add them to the ViewBag.
            ViewBag.Products = Ref_OnlineShopEntities.Product;
            return View();
        }
        public ActionResult FillGrid([DataSourceRequest] DataSourceRequest request)
        {
            Models.DomainModels.DTO.EF.OnlineShopEntities db_onlineShop = new OnlineShopEntities();
            IQueryable<Product> product = db_onlineShop.Product;
            DataSourceResult result = product.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}