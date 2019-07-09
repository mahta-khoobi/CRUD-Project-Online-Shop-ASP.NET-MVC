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
            Ref_ProductCategoryCrud = new DomainModels.POCO.ProductCategoryCrud();
            Ref_UnitOfWork = new Framework.Base.UnitOfWork<DomainModels.DTO.EF.OnlineShopEntities, DomainModels.DTO.EF.ProductCategory, int>(new DomainModels.POCO.ProductCategoryRepository(new DomainModels.DTO.EF.OnlineShopEntities()));
        }
    
    #endregion
    public Framework.Base.UnitOfWork<DomainModels.DTO.EF.OnlineShopEntities, DomainModels.DTO.EF.ProductCategory, System.Int32> Ref_UnitOfWork { get; set; }

    #region [-Save(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory)-]
    public void Save(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
    {
        Ref_UnitOfWork.Ref_IUnitOfWork.Create(ref_ProductCategory);
    }
    #endregion



        #region [-props for class-]
        public Models.DomainModels.DTO.EF.ProductCategory Ref_ProductCateory { get; set; }
        public Models.DomainModels.POCO.ProductCategoryCrud Ref_ProductCategoryCrud { get; set; }
        #endregion

        #region [-props for Model-]
        public int Id { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        #endregion

        //#region [- Save(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory) -]
        //public void Save(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
        //{
        //    Ref_ProductCategoryCrud.Insert(ref_ProductCategory);
        //}
        //#endregion

        #region [- FillGrid() -]
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

        #region [- Edit(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory) -]
        public void Edit(Models.DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
        {
           
            Ref_UnitOfWork.Ref_IUnitOfWork.Update(ref_ProductCategory);

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