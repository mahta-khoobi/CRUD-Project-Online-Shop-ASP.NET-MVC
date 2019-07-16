using Sample02.Models.DomainModels.DTO.EF;
using Sample02.Models.Helper.SPHelper.ProductCategory;
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

            Ref_UnitOfWork = new Framework.Base.UnitOfWork<DomainModels.DTO.EF.OnlineShopEntities, DomainModels.DTO.EF.ProductCategory, int,CategorySelectHelper>(new DomainModels.POCO.ProductCategoryRepository(new DomainModels.DTO.EF.OnlineShopEntities()));
        }

        #endregion

        #region [-props for class-]
        public Framework.Base.UnitOfWork<DomainModels.DTO.EF.OnlineShopEntities, DomainModels.DTO.EF.ProductCategory, System.Int32,CategorySelectHelper> Ref_UnitOfWork { get; set; }
        public Models.DomainModels.DTO.EF.ProductCategory Ref_ProductCateory { get; set; }

        #endregion

        #region [-props for Model-]
        public int Id { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        #endregion

        #region [-Save(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory)-]
        public void Save(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
    {
        Ref_UnitOfWork.Ref_IUnitOfWork.Create(ref_ProductCategory);
    }
        #endregion

        #region [-SaveBySP(List<CategorySaveHelper> listCategorySaveHelper)-]
        public void SaveBySP(List<CategorySaveHelper> listCategorySaveHelper)
        {
            Ref_UnitOfWork.Ref_IUnitOfWork.CrudBySP(
                CategorySPHelper.usp_Category_Insert,
                CategorySPHelper.SetInsertParameters(listCategorySaveHelper)
                );
        } 
        #endregion

        #region [- Edit(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory) -]
        public void Edit(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
        {

            Ref_UnitOfWork.Ref_IUnitOfWork.Update(ref_ProductCategory);

        }
        #endregion

        #region [- EditBySP(List<CategorySelectHelper> listCategorySelectHelper) -]
        public void EditBySP(List<CategorySelectHelper> listCategorySelectHelper)
        {

            Ref_UnitOfWork.Ref_IUnitOfWork.CrudBySP(
                CategorySPHelper.usp_Category_Update,
                CategorySPHelper.SetUpdateParameters(listCategorySelectHelper)
                );


        }
        #endregion

        #region [-Delete(int id)-]
        public void Delete(int id)
        {
            Ref_ProductCateory = new Models.DomainModels.DTO.EF.ProductCategory();
            Ref_ProductCateory.Id = id;
            Ref_UnitOfWork.Ref_IUnitOfWork.Delete(Ref_ProductCateory);

        }

        #endregion

        #region [-GetRecord(int id)-]
        public Models.DomainModels.DTO.EF.ProductCategory GetRecord(int id)
        {
            return Ref_UnitOfWork.Ref_IUnitOfWork.FindById(id);
        }
        #endregion

        #region [- FillGrid() -]
        public List<ProductCategory> FillGrid() //goftim dynamic k moshkele view dar refresh hal shavad va lazem nist list bargardanad
        {
            return Ref_UnitOfWork.Ref_IUnitOfWork.Select();
        }
        #endregion

        #region [-FillGridBySP()-]
        public List<CategorySelectHelper> FillGridBySP()
        {
            return Ref_UnitOfWork.Ref_IUnitOfWork.SelectBySP(
                CategorySPHelper.usp_ProductCategory_Select,
                null

                );
        } 
        #endregion
    }
}