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
        public Nullable<int> Category_Ref { get; set; }

        public virtual Models.DomainModels.DTO.EF.ProductCategory ProductCategory { get; set; }
        #endregion

        #region [- Save() -]
        public void Save(Models.DomainModels.DTO.EF.Product ref_Product)
        {
            
            Ref_ProductCrud.Insert(ref_Product);

        }
        #endregion

        #region [-FillGrid()-]
        public dynamic FillGrid()
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

        #region [- Edit() -]
        public void Edit(Models.DomainModels.DTO.EF.Product ref_Product)
        {
            
            Ref_ProductCrud.Update(ref_Product);

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