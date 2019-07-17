using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.Helper.SPHelper.Order
{
    public class OrderSPHelper
    {
       
        public const string usp_Order_Select = "[dbo].[usp_Order_Select]";
        public const string usp_Order_Insert = "[dbo].[usp_Order_Insert] @orderMasterList , @orderDetailsList";


        #region [-SetInsertParameters(List<ProductSaveHelper> listProductSaveHelper)-]
        public static object[] SetInsertParameters(List<OrderMasterSaveHelper> listProductSaveHelper)
        {
            #region [-SqlParameter-]
            SqlParameter productListParameter = new SqlParameter()
            {
                ParameterName = "@productInfo_Insert",
                SqlDbType = System.Data.SqlDbType.Structured,
                TypeName = "dbo.udt_ProductInfo_Insert",
                Value = listProductSaveHelper.ToDataTable()
            };
            #endregion

            #region [-parameters-]

            object[] parameters =
                {
                productListParameter
                };
            #endregion

            return parameters;
        }
        #endregion


    }
}