using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    public class OrderController : Controller
    {
        #region [-ctor-]
        public OrderController()
        {
            Ref_OrderViewModel = new Models.ViewModels.OrderViewModel();
        }

        #endregion
        public Sample02.Models.ViewModels.OrderViewModel Ref_OrderViewModel { get; set; }
        // GET: Order
        #region [-Order()-]
        public ActionResult Order()
        {
            return View();
        }
        #endregion

        #region [- FillGrid([DataSourceRequest] DataSourceRequest request) -]
        public JsonResult FillGrid([DataSourceRequest] DataSourceRequest request)
        {

            IEnumerable<Models.DomainModels.DTO.EF.OrderMaster> q = Ref_OrderViewModel.FillGrid();

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- Create() -]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,OrderCode,OrderDate,Customer_Ref")] Sample02.Models.DomainModels.DTO.EF.OrderMaster orderMaster)
        {

            if (ModelState.IsValid)
            {
               // Ref_OrderViewModel.Save(orderMaster,I);
                return RedirectToAction("FillGrid");
            }

            return RedirectToAction("FillGrid");


        }


        #endregion
    }
}