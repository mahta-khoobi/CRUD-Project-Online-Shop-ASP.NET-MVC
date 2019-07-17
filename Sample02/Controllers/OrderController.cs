using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample02.Models.Helper.SPHelper.Order;
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

            IEnumerable<OrderSelectHelper> q = Ref_OrderViewModel.FillGridBySP();

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- FillOrderDetailsGrid([DataSourceRequest] DataSourceRequest request, int id) -]
     
        public JsonResult FillOrderDetailsGrid([DataSourceRequest] DataSourceRequest request, int? id)
        {
            List<Models.DomainModels.DTO.EF.usp_GetOrderDetailsGivenOrderMasterId_Result> q = null; 
            if (id != null)
            {
                // Ref_OrderViewModel.Id = id;
               q = Ref_OrderViewModel.GetOrderDetailsGrid(id);

                
            }
            //return new JsonResult { };
            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region [- Create() -]

        [HttpPost]
        public JsonResult Create([Bind(Include = "OrderMasterList,OrderDetailsList")] Sample02.Models.ViewModels.OrderViewModel ref_OrderViewModel)
        {
            Ref_OrderViewModel.OrderMasterList = new List<OrderMasterListSaveHelper>();
            Ref_OrderViewModel.OrderMasterList = ref_OrderViewModel.OrderMasterList;
            bool status = false;
            
            Ref_OrderViewModel.SaveBySP(Ref_OrderViewModel.OrderMasterList, ref_OrderViewModel.OrderDetailsList);
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