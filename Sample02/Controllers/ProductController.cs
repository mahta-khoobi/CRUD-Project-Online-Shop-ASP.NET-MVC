﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample02.Models.DomainModels.DTO.EF;
using Sample02.Models.Helper.SPHelper.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    public class ProductController : Controller
    {
        #region [- ctor -]
        public ProductController()
        {
            Ref_ProductViewModel = new Models.ViewModels.ProductViewModel();
        }
        #endregion

        #region [-props-]
        public Sample02.Models.ViewModels.ProductViewModel Ref_ProductViewModel { get; set; }
        #endregion

        #region [-Actions-]

        #region [-Product()-]
        public ActionResult Product()
        {
            return View(Ref_ProductViewModel);
        }

        #endregion

        #region [- FillGrid([DataSourceRequest] DataSourceRequest request) -]
        public JsonResult FillGrid([DataSourceRequest] DataSourceRequest request)
        {

            IEnumerable<ProductSelectHelper> q = Ref_ProductViewModel.FillGridBySP();

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- Create() -]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,ProductCode,ProductName,ProductDescription,UnitPrice,Category_Ref")] ProductSaveHelper product)
        {
            List<ProductSaveHelper> listProductInfo = new List<ProductSaveHelper>();
            listProductInfo.Add(product);

            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.SaveBySP(listProductInfo);
                return RedirectToAction("FillGrid");
            }

            return RedirectToAction("FillGrid");


        }


        #endregion

        #region [- Edit() -]
        [HttpPost]

        public ActionResult Edit([Bind(Include = "Id,ProductCode,ProductName,ProductDescription,UnitPrice,Category_Ref")] ProductEditHelper product)
        {
            List<ProductEditHelper> listProductInfo = new List<ProductEditHelper>();
            listProductInfo.Add(product);

            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.EditBySP(listProductInfo);
                return RedirectToAction("FillGrid");
            }

            return RedirectToAction("FillGrid");
        }
        #endregion

        #region [- Delete() -]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.DeleteBySP(id);
                return RedirectToAction("FillGrid");
            }
            else
            {
                return RedirectToAction("FillGrid");
            }

        }
        #endregion

        //public IEnumerable<Sample02.Models.DomainModels.DTO.EF.Product> GetProductCategoryList()
        //{
        //    var result = Ref_ProductViewModel.FillGrid();
        //    return result;
        //    //return (DataSourceResult(result), JsonRequestBehavior.AllowGet);
        //}

        #endregion
    }
}