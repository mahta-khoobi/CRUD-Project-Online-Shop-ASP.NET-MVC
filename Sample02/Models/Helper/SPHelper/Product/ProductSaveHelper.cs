using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.Helper.SPHelper.Product
{
    public class ProductSaveHelper
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int Category_Ref { get; set; }
    }
}