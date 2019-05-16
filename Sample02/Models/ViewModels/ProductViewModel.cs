using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.ViewModels
{
    public class ProductViewModel
    {
        #region [-ctor-]
        public ProductViewModel()
        {
            Ref_ProductCrud = new DomainModels.POCO.ProductCrud();
        }
        #endregion

        #region [-props for class-]
        public Models.DomainModels.DTO.EF.Product Ref_Product { get; set; }
        public Models.DomainModels.POCO.ProductCrud Ref_ProductCrud { get; set; }
        #endregion

        #region [-props for Model-]
        public int Id { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int Category_Ref { get; set; }
        #endregion


        #region [- Save(int productCode, string productName, string productDescription,decimal unitPrice,int category_ref) -]
        public void Save(int productCode, string productName, string productDescription,decimal unitPrice,int category_ref)
        {
            Ref_Product = new Models.DomainModels.DTO.EF.Product();
            Ref_Product.ProductCode = productCode;
            Ref_Product.ProductName = productName;
            Ref_Product.ProductDescription = productDescription;
            Ref_Product.UnitPrice = unitPrice;
            Ref_Product.Category_Ref = category_ref;
            Ref_ProductCrud.Insert(Ref_Product);

        }
        #endregion

        #region [-dynamic FillGrid()-]
        public List<Models.DomainModels.DTO.EF.Product> FillGrid()
        {
            return Ref_ProductCrud.SelectAll();
        }
        #endregion

        #region [-Delete(int id)-]
        public void Delete(int id)
        {
            Ref_Product = new Models.DomainModels.DTO.EF.Product();
            Ref_Product.Id = id;
            Ref_ProductCrud.Remove(Ref_Product);

        }

        #endregion

        #region [- Edit(int id, int productCode, string productName, string productDescription, decimal unitPrice, int category_ref) -]
        public void Edit(int id, int productCode, string productName, string productDescription, decimal unitPrice, int category_ref)
        {
            Ref_Product = new Models.DomainModels.DTO.EF.Product();
            Ref_Product.Id =id;
            Ref_Product.ProductCode = productCode;
            Ref_Product.ProductName = productName;
            Ref_Product.ProductDescription = productDescription;
            Ref_Product.UnitPrice = unitPrice;
            Ref_Product.Category_Ref = category_ref;
            Ref_ProductCrud.Update(Ref_Product);

        }
        #endregion

        #region [-GetRecord(int? id)-]
        public Models.DomainModels.DTO.EF.Product GetRecord(int? id)
        {
            return Ref_ProductCrud.FindRecord(id);
        }
        #endregion


    }
}