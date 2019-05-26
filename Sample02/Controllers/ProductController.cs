﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Sample02.Models.DomainModels.DTO.EF;
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

            IEnumerable<Models.DomainModels.DTO.EF.Product> q = Ref_ProductViewModel.FillGrid();

            return Json(q.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region [- Create() -]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,ProductCode,ProductName,ProductDescription,UnitPrice,Category_Ref")] Product product)
        {

            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.Save(product);
                return RedirectToAction("Product");
            }
            else { return View("Product"); }



        }


        #endregion

        #region [- Edit() -]
        [HttpPost]

        public ActionResult Edit([Bind(Include = "Id,ProductCode,ProductName,ProductDescription,UnitPrice,Category_Ref")] Product product)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.Edit(product);
                return RedirectToAction("Product");
            }
            else
            {
                return View("Product");
            }
        }
        #endregion

        #region [- Delete() -]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.Delete(id);
                return RedirectToAction("Product");
            }
            else
            {
                return View("Product");
            }

        }
        #endregion

        #endregion
    }
}