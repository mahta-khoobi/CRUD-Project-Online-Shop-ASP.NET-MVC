using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.DomainModels.POCO
{
    public class ProductCategoryRepository : Models.Framework.Base.BaseRepository<Models.DomainModels.DTO.EF.OnlineShopEntities, Models.DomainModels.DTO.EF.ProductCategory, int>
    {
        #region [- ctor -]
        public ProductCategoryRepository(Models.DomainModels.DTO.EF.OnlineShopEntities context) : base(context)
        {

        }
        #endregion

    }
}
