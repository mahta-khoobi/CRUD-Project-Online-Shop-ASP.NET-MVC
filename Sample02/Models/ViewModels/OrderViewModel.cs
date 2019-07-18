using Sample02.Models.DomainModels.DTO.EF;
using Sample02.Models.Helper.SPHelper.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Sample02.Models.ViewModels
{
    public class OrderViewModel
    {
        #region [-ctor-]
        public OrderViewModel()
        {
            //Ref_OrderCrud = new DomainModels.POCO.OrderCrud();
            OrderDetail_Ref = new DomainModels.DTO.Helper.OrderHelper();
            Ref_UnitOfWork = new Framework.Base.UnitOfWork<OnlineShopEntities, OrderMaster, int, OrderSelectHelper>(new Models.DomainModels.POCO.OrderRepository(new OnlineShopEntities()));
        }
        #endregion

        #region [-props for class-]
       // public Models.DomainModels.POCO.OrderCrud Ref_OrderCrud { get; set; }
        public Models.Framework.Base.UnitOfWork<OnlineShopEntities, OrderMaster, int, OrderSelectHelper> Ref_UnitOfWork { get; set; }

        #endregion

        #region [-props for model-]
        public int Id { get; set; }
        public int OrderCode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Customer_Ref { get; set; }

        public Models.DomainModels.DTO.Helper.OrderHelper OrderDetail_Ref { get; set; }
        public List<Models.Helper.SPHelper.Order.OrderMasterListSaveHelper> OrderMasterList { get; set; }
        public List<Models.Helper.SPHelper.Order.OrderDetailsListSaveHelper> OrderDetailsList { get; set; }
        #endregion

        #region [-FillGrid()-]
        public List<OrderMaster> FillGrid()
        {
           return Ref_UnitOfWork.Ref_IUnitOfWork.Select();
        }
        #endregion

        #region [-FillGridBySP()-]
        public List<OrderSelectHelper> FillGridBySP()
        {
            return Ref_UnitOfWork.Ref_IUnitOfWork.SelectBySP(
                OrderSPHelper.usp_Order_Select,
                null
                );
        }
        #endregion

        #region [-SaveBySP()-]
        public void SaveBySP(List<OrderMasterListSaveHelper> ref_OrderMasterList, List<OrderDetailsListSaveHelper> ref_OrderDetailsList)
        {
            Ref_UnitOfWork.Ref_IUnitOfWork.CrudBySP(
                OrderSPHelper.usp_Order_Insert,
                OrderSPHelper.SetInsertParameters(ref_OrderMasterList,ref_OrderDetailsList)
                
                );

        }
        #endregion

        #region [-DeleteBySP(int id)-]
        public void DeleteBySP(int id)
        {
            
            Ref_UnitOfWork.Ref_IUnitOfWork.CrudBySP(
                OrderSPHelper.usp_Order_Delete,
                OrderSPHelper.SetDeleteParameters(id)
                );
        }
        #endregion

        #region [-GetOrderDetailsGrid(int id)-]
        //public List<Models.DomainModels.DTO.EF.usp_GetOrderDetailsGivenOrderMasterId_Result> GetOrderDetailsGrid(int? id)
        //{
     
        //    return Ref_OrderCrud.SelectOrderDetailsGivenOrdeMasterId(id);
        //}
        #endregion

    }
}