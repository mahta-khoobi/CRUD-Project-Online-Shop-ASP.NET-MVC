using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.ViewModels
{
    public class ProductCategoryViewModel
    {
        #region [-ctor-]
        public ProductCategoryViewModel()
        {
            Ref_ProductCategoryCrud = new Models.DomainModels.POCO.ProductCategoryCrud();
        }
        #endregion

        public Models.DomainModels.DTO.EF.ProductCategory Ref_ProductCateory { get; set; }
        public Models.DomainModels.POCO.ProductCategoryCrud Ref_ProductCategoryCrud { get; set; }

        #region [- Save(string categoryName) -]
        public void Save(int categoryCode,string categoryName)
        {
            Ref_ProductCateory = new Models.DomainModels.DTO.EF.ProductCategory();
            Ref_ProductCateory.CategoryCode = categoryCode;
            Ref_ProductCateory.CategoryName = categoryName;
            Ref_ProductCategoryCrud.Insert(Ref_ProductCateory);

        }
        #endregion

        #region [-dynamic FillGrid()-]
        public dynamic FillGrid() //goftim dynamic k moshkele view dar refresh hal shavad va lazem nist list bargardanad
        {
            return Ref_ProductCategoryCrud.SelectAll();
        }
        #endregion

        #region [-Delete(int id)-]
        public void Delete(int id)
        {
            Ref_ProductCateory = new Models.DomainModels.DTO.EF.ProductCategory();
            Ref_ProductCateory.Id = id;

            Ref_ProductCategoryCrud.Remove(Ref_ProductCateory);

        }

        #endregion

        #region [- Edit(int id, int categoryCode, string categoryName) -]
        public void Edit(int id,int categoryCode, string categoryName)
        {
            Ref_ProductCateory = new Models.DomainModels.DTO.EF.ProductCategory();
            Ref_ProductCateory.Id = id;
            Ref_ProductCateory.CategoryCode = categoryCode;
            Ref_ProductCateory.CategoryName = categoryName;
            Ref_ProductCategoryCrud.Update(Ref_ProductCateory);

        }
        #endregion

        #region [-GetRecord(int? id)-]
        public Models.DomainModels.DTO.EF.ProductCategory GetRecord(int? id)
        {
            return Ref_ProductCategoryCrud.FindRecord(id);
        } 
        #endregion
    }
}