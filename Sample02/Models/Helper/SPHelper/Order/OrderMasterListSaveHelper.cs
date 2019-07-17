using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.Helper.SPHelper.Order
{
    public class OrderMasterListSaveHelper
    {
        public int OrderCode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Customer_Ref { get; set; }
    }
}