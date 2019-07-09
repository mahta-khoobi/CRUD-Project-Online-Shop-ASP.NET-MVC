using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample02.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    public class ProductCategoryController : Controller
    {
        #region [-ctor-]
        public ProductCategoryController()
        {
            Ref_ProductCategoryViewModel = new Models.ViewModels.ProductCategoryViewModel();
        }
        #endregion

        #region [-Properties-]
        public Models.ViewModels.ProductCategoryViewModel Ref_ProductCategoryViewModel { get; set; }
        #endregion

        #region [-Actions-]

        #region [-ProductCategory()-]
        public ActionResult ProductCategory()
        {
            return View(Ref_ProductCategoryViewModel);
        }

        #endregion

        #region [- FillGrid([DataSourceRequest] DataSourceRequest request) -]
         public JsonResult FillGrid([DataSourceRequest] DataSourceRequest request)
        {
            //Models.DomainModels.DTO.EF.OnlineShopEntities db_onlineShop = new OnlineShopEntities();
            //IQueryable<ProductCategory> productCategory = db_onlineShop.ProductCategory;
            //DataSourceResult result = productCategory.ToDataSourceResult(request);

            //return Json(result,JsonRequestBehavior.AllowGet);
            IEnumerable<Models.DomainModels.DTO.EF.ProductCategory> q = Ref_ProductCategoryViewModel.FillGrid();
            //var q = Ref_CategoryViewModel.FillGrid();
             return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- Create() -]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,CategoryCode,CategoryName")] ProductCategory productCategory)
        {

            if (ModelState.IsValid)
            {
                Ref_ProductCategoryViewModel.Save(productCategory);
                return RedirectToAction("ProductCategory");
            }
            else { return View("ProductCategory"); }

            

        }


        #endregion

        #region [- Edit() -]
        [HttpPost]
 
        public ActionResult Edit([Bind(Include = "Id,CategoryCode,CategoryName")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {

                Ref_ProductCategoryViewModel.Edit(productCategory);
                return RedirectToAction("ProductCategory");
            }
            else
            {
                return View("ProductCategory");
            }
        }
        #endregion

        #region [- Delete() -]
        [HttpPost]     
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductCategoryViewModel.Delete(id);
                return RedirectToAction("ProductCategory");
            }
            else
            {
                return View("ProductCategory");
            }
            
        }
        #endregion

        #endregion



    }
}