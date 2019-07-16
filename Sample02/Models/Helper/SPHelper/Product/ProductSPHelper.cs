using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sample02.Models.Helper.SPHelper.Product
{
    public class ProductSPHelper
    {
        public const string usp_Product_Select = "[dbo].[usp_Product_Select]";
        public const string usp_Product_Insert = "[dbo].[usp_Product_Insert] @productInfo_Insert";

        #region [-SetInsertParameters(List<CategorySaveHelper> listCategorySaveHelper))-]
        public static object[] SetInsertParameters(List<ProductSaveHelper> listProductSaveHelper)
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