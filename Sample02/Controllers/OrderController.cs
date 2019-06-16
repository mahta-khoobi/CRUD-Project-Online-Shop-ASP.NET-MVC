using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
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

        #region [-props-]
        public Sample02.Models.ViewModels.OrderViewModel Ref_OrderViewModel { get; set; }
        #endregion

        #region [-Actions-]
        #region [-Order()-]
        public ActionResult Order()
        {
            return View();
        }
        #endregion

        #region [- FillGrid([DataSourceRequest] DataSourceRequest request) -]
        public JsonResult FillGrid([DataSourceRequest] DataSourceRequest request)
        {

            IEnumerable<Models.DomainModels.DTO.EF.usp_OrderMaster_Select_Result> q = Ref_OrderViewModel.FillGrid();

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- FillOrderDetailsGrid([DataSourceRequest] DataSourceRequest request, int id) -]
        public JsonResult FillOrderDetailsGrid([DataSourceRequest] DataSourceRequest request, int id)
        {


            List<Models.DomainModels.DTO.EF.usp_GetOrderDetailsGivenOrderMasterId_Result> q = Ref_OrderViewModel.GetOrderDetailsGrid(id);

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        } 
        #endregion

        #region [- Create() -]

        [HttpPost]
        public JsonResult Create([Bind(Include = "Id,OrderCode,OrderDate,Customer_Ref,OrderDetails,OrderDetail_Ref,Ref_OrderCrud")] Sample02.Models.ViewModels.OrderViewModel ref_OrderViewModel)
        {

            bool status = false;
            Models.DomainModels.DTO.EF.OrderMaster ref_OrderMaster = new Models.DomainModels.DTO.EF.OrderMaster();
            ref_OrderMaster.OrderCode = ref_OrderViewModel.OrderCode;
            ref_OrderMaster.OrderDate = ref_OrderViewModel.OrderDate;
            ref_OrderMaster.Customer_Ref = ref_OrderViewModel.Customer_Ref;



            Ref_OrderViewModel.Save(ref_OrderMaster, ref_OrderViewModel.OrderDetails);
            status = true;




            return new JsonResult { Data = new { status = status } };
        }


        #endregion

        #region [- Delete() -]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Ref_OrderViewModel.Delete(id);
                return RedirectToAction("FillGrid");
            }
            else
            {
                return RedirectToAction("FillGrid");
            }

        }
        #endregion 
        #endregion
    }
}