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
        public const string usp_Product_Update = "[dbo].[usp_Product_Update] @productInfo_Update";
        public const string usp_Product_Delete= "[dbo].[usp_Product_Delete] @id";

        #region [-SetInsertParameters(List<ProductSaveHelper> listProductSaveHelper)-]
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


        #region [-SetUpdateParameters(List<ProductEditHelper> listProductEditHelper)-]
        public static object[] SetUpdateParameters(List<ProductEditHelper> listProductEditHelper)
        {
            #region [-SqlParameter-]
            SqlParameter productListParameter = new SqlParameter()
            {
                ParameterName = "@productInfo_Update",
                SqlDbType = System.Data.SqlDbType.Structured,
                TypeName = "dbo.udt_ProductInfo_Update",
                Value = listProductEditHelper.ToDataTable()
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

        #region [-SetDeleteParameters(int id)-]
        public static object[] SetDeleteParameters(int id)
        {
            #region [-SqlParameter-]
            SqlParameter productDeleteParameter = new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = id
            };
            #endregion

            #region [-parameters-]

            object[] parameters =
                {
                productDeleteParameter
                };
            #endregion

            return parameters;
        }
        #endregion

    }
}