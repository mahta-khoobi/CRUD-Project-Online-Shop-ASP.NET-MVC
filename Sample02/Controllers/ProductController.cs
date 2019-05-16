using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    public class ProductController : Controller
    {
        #region [-ctor-]
        public ProductController()
        {
            Ref_ProductViewModel = new Models.ViewModels.ProductViewModel();
        }
        #endregion

        #region [-props-]
        public Models.ViewModels.ProductViewModel Ref_ProductViewModel { get; set; }
        #endregion
        #region [-Index()-]
        public ActionResult Index()
        {
            return View(Ref_ProductViewModel);
        } 
        #endregion
    }
}