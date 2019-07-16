using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample02.Models.DomainModels.DTO.EF;
using Sample02.Models.Helper.SPHelper.Product;

namespace Sample02.Models.ViewModels
{
    public class ProductViewModel
    {
        #region [-ctor-]
        public ProductViewModel()
        {
            Ref_ProductCrud = new DomainModels.POCO.ProductCrud();
            Ref_ProductCategoryViewModel = new ProductCategoryViewModel();
            Ref_UnitOfWork = new Framework.Base.UnitOfWork<OnlineShopEntities, Product, int, ProductSelectHelper>(new Models.DomainModels.POCO.ProductRepository(new OnlineShopEntities()));
        }
        #endregion

        #region [-props for class-]

        public Models.DomainModels.POCO.ProductCrud Ref_ProductCrud { get; set; }
        public Models.ViewModels.ProductCategoryViewModel Ref_ProductCategoryViewModel { get; set; }
        public Framework.Base.UnitOfWork<OnlineShopEntities, Product, int, ProductSelectHelper> Ref_UnitOfWork { get; set; }

        #endregion

        #region [-props for Model-]
        public int Id { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int Category_Ref { get; set; }

       // public virtual Models.DomainModels.DTO.EF.ProductCategory ProductCategory { get; set; }
        #endregion

        #region [- Save() -]
        public void Save(Models.DomainModels.DTO.EF.Product ref_Product)
        {

            Ref_UnitOfWork.Ref_IUnitOfWork.Create(ref_Product);

        }
        #endregion

        #region [-SaveBySP(List<ProductSaveHelper> listProductSaveHelper)-]
        public void SaveBySP(List<ProductSaveHelper> listProductSaveHelper)
        {
            Ref_UnitOfWork.Ref_IUnitOfWork.CrudBySP(
                ProductSPHelper.usp_Product_Insert,
                ProductSPHelper.SetInsertParameters(listProductSaveHelper)
                );
        }
        #endregion

        #region [-FillGrid()-]
        public List<Product> FillGrid()
        {
            return Ref_UnitOfWork.Ref_IUnitOfWork.Select();
        }
        #endregion

        #region [-FillGridBySP()-]
        public List<ProductSelectHelper> FillGridBySP()
        {
            return Ref_UnitOfWork.Ref_IUnitOfWork.SelectBySP(
                ProductSPHelper.usp_Product_Select,
                null

                );
        }
        #endregion

        #region [-Delete(int id)-]
        public void Delete(int id)
        {
     
            Ref_UnitOfWork.Ref_IUnitOfWork.Delete(id);

        }

        #endregion

        #region [- Edit() -]
        public void Edit(Models.DomainModels.DTO.EF.Product ref_Product)
        {

            Ref_UnitOfWork.Ref_IUnitOfWork.Update(ref_Product);

        }
        #endregion

        #region [-GetRecord(int? id)-]
        public Models.DomainModels.DTO.EF.Product GetRecord(int id)
        {
            return Ref_UnitOfWork.Ref_IUnitOfWork.FindById(id);
        }
        #endregion

    }
}