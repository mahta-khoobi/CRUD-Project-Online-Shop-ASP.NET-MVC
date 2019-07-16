using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sample02.Models.Helper.SPHelper.ProductCategory
{
    public class CategorySPHelper
    {
        public const string usp_ProductCategory_Select = "[dbo].[usp_ProductCategory_Select]";
        public const string usp_Category_Insert = "[dbo].[usp_Category_Insert] @categoryInfo";
        public const string usp_Category_Update = "[dbo].[usp_Category_Update] @categoryInfoUpdate";
        public const string usp_Category_Delete = "[dbo].[usp_Category_Delete] @id";




        #region [-SetInsertParameters(List<CategorySaveHelper> listCategorySaveHelper))-]
        public static object[] SetInsertParameters(List<CategorySaveHelper> listCategorySaveHelper)
        {
            #region [-SqlParameter-]
            SqlParameter categoryListParameter = new SqlParameter()
            {
                ParameterName = "@categoryInfo",
                SqlDbType = System.Data.SqlDbType.Structured,
                TypeName = "dbo.udt_CategoryInfo",
                Value = listCategorySaveHelper.ToDataTable()
            };
            #endregion

            #region [-parameters-]

            object[] parameters =
                {
                categoryListParameter
                };
            #endregion

            return parameters;
        }
        #endregion

        #region [-SetUpdateParameters(List<CategorySelectHelper> listCategorySelectHelper)-]
        public static object[] SetUpdateParameters(List<CategorySelectHelper> listCategorySelectHelper)
        {
            #region [-SqlParameter-]
            SqlParameter categoryListParameter = new SqlParameter()
            {
                ParameterName = "@categoryInfoUpdate",
                SqlDbType = System.Data.SqlDbType.Structured,
                TypeName = "dbo.udt_CategoryInfoUpdate",
                Value = listCategorySelectHelper.ToDataTable()
            };
            #endregion

            #region [-parameters-]

            object[] parameters =
                {
                categoryListParameter
                };
            #endregion

            return parameters;
        }
        #endregion

        #region [-SetDeleteParameters(int id)-]
        public static object[] SetDeleteParameters(int id)
        {
            #region [-SqlParameter-]
            SqlParameter categoryDeleteParameter = new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = id
            };
            #endregion

            #region [-parameters-]

            object[] parameters =
                {
                categoryDeleteParameter
                };
            #endregion

            return parameters;
        }
        #endregion
    }
}