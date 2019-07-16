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


        #region [-SetInsertParameters(List<CategorySelectHelper> listCategorySelectHelper)-]
        public static object[] SetInsertParameters(List<CategorySaveHelper> listCategorySelectHelper)
        {
            #region [-SqlParameter-]
            SqlParameter categoryListParameter = new SqlParameter()
            {
                ParameterName = "@categoryInfo",
                SqlDbType = System.Data.SqlDbType.Structured,
                TypeName = "dbo.udt_CategoryInfo",
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
    }
}