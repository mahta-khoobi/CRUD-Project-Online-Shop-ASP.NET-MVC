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

        #region [- Create()  -]
        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region [- Create() :Post -]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,CategoryCode,CategoryName")] ProductCategory productCategory)
        {

            if (ModelState.IsValid)
            {
                Ref_ProductCategoryViewModel.Save(productCategory.CategoryCode, productCategory.CategoryName);

                return RedirectToAction("Index");
            }

            return View(Ref_ProductCategoryViewModel);

        }


        #endregion

        #region [- Edit() :Get -]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // return RedirectToAction("index");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Ref_ProductCategoryViewModel.GetRecord(id) == null)
            {
                return HttpNotFound();
            }

            return View(Ref_ProductCategoryViewModel);


        }
        #endregion

        #region [- Edit() :Post -]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,CategoryCode,CategoryName")] ProductCategory productCategory)
        {
            Ref_ProductCategoryViewModel.Edit(productCategory.Id, productCategory.CategoryCode, productCategory.CategoryName);
            return RedirectToAction("Index");
        }
        #endregion

        #region [- Delete() :Get -]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Ref_ProductCategoryViewModel.GetRecord(id) == null)
            {
                return HttpNotFound();
            }
            return View(Ref_ProductCategoryViewModel);
        }
        #endregion

        #region [- DeleteConfirmed() :Post -]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Ref_ProductCategoryViewModel.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion

        #endregion



    }
}