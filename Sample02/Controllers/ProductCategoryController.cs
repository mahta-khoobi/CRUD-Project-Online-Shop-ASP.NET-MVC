﻿using System;
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

        // GET: ProductCategory
        #region [-Index()-]
        public ActionResult Index()
        {
            return View(Ref_ProductCategoryViewModel.FillGrid());
        }
        #endregion


        #endregion

        #region [- Create()  -]
        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region [- Create() :Post -]
        [HttpPost]
        public ActionResult Create(int CatrgoryCode, string CategoryName)
        {
            Ref_ProductCategoryViewModel.Save(CatrgoryCode, CategoryName);

            return RedirectToAction("Index");
        }

        #endregion

        #region [- Edit() :Get -]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return RedirectToAction("index");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Ref_ProductCategoryViewModel.GetRecord(id) == null)
            {
                return HttpNotFound();
            }
            
                return View(Ref_ProductCategoryViewModel.GetRecord(id));
            
        }
        #endregion

        #region [- Edit() :Post -]
        [HttpPost]
        public ActionResult Edit(int id,int categoryCode,string categoryName )
        {
            Ref_ProductCategoryViewModel.Edit(id,categoryCode,categoryName);
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
            return View(Ref_ProductCategoryViewModel.GetRecord(id));
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

    }
}