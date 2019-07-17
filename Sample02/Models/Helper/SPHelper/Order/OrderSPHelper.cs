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


    }
}