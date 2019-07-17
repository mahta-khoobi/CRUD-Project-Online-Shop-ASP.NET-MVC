using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sample02.Models.Helper.SPHelper.Order
{
    public class OrderSPHelper
    {
       
        public const string usp_Order_Select = "[dbo].[usp_Order_Select]";
        public const string usp_Order_Insert = "[dbo].[usp_Order_Insert] @orderMasterList , @orderDetailsList";


        #region [-SetInsertParameters(List<ProductSaveHelper> listProductSaveHelper)-]
        public static object[] SetInsertParameters(List<OrderMasterListSaveHelper> listOrderMaster, List<OrderDetailsListSaveHelper> listOrderDetails)
        {
            #region [-SqlParameter-]
            SqlParameter orderMasterListParameter = new SqlParameter()
            {
                ParameterName = "@orderMasterList",
                SqlDbType = System.Data.SqlDbType.Structured,
                TypeName = "dbo.udt_OrderMasterList",
                Value = listOrderMaster.ToDataTable()
            };


            SqlParameter orderDetailsListParameter = new SqlParameter()
            {
                ParameterName = "@orderDetailsList",
                SqlDbType = System.Data.SqlDbType.Structured,
                TypeName = "dbo.udt_OrderDetailsList",
                Value = listOrderDetails.ToDataTable()
            };
            #endregion

            #region [-parameters-]

            object[] parameters =
                {
                orderMasterListParameter,orderDetailsListParameter
                };
            #endregion

            return parameters;
        }
        #endregion


    }
}