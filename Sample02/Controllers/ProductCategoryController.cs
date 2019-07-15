using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample02.Models.DomainModels.DTO.EF;
using Sample02.Models.Helper.SPHelper.ProductCategory;
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

            IEnumerable<ProductCategory> q = Ref_ProductCategoryViewModel.FillGrid();

             return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- FillGridBySP([DataSourceRequest] DataSourceRequest request) -]
        public JsonResult FillGridBySP([DataSourceRequest] DataSourceRequest request)
        {

            IEnumerable<CategorySelectHelper> q = Ref_ProductCategoryViewModel.FillGridBySP();

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- Create() -]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,CategoryCode,CategoryName")] CategorySaveHelper productCategory)
        {
            List<CategorySaveHelper> listCategory = new List<CategorySaveHelper>();
            listCategory.Add(productCategory);
            if (ModelState.IsValid)
            {
                // Ref_ProductCategoryViewModel.Save(productCategory);
                Ref_ProductCategoryViewModel.SaveBySP(listCategory);
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