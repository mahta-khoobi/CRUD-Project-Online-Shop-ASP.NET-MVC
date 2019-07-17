using Sample02.Models.Helper.SPHelper.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.DomainModels.POCO
{
    public class OrderRepository: Models.Framework.Base.BaseRepository<Models.DomainModels.DTO.EF.OnlineShopEntities, Models.DomainModels.DTO.EF.OrderMaster, System.Int32, OrderSelectHelper>
    {


        #region [-ctor-]
        public OrderRepository(Models.DomainModels.DTO.EF.OnlineShopEntities context) :base(context)
        {

        } 
        #endregion
    }
}