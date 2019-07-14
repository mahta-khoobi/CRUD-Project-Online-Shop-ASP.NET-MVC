using Sample02.Models.Helper.SPHelper.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.DomainModels.POCO
{
    public class ProductRepository : Models.Framework.Base.BaseRepository<Models.DomainModels.DTO.EF.OnlineShopEntities,Models.DomainModels.DTO.EF.Product,System.Int32,ProductSelectHelper>
    {
        #region [-ctor-]
        public ProductRepository(Models.DomainModels.DTO.EF.OnlineShopEntities context) : base(context)
        {

        } 
        #endregion
    }
}