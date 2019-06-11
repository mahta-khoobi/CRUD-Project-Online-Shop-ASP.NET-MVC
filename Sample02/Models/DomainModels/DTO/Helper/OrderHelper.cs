using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.DomainModels.DTO.Helper
{
    public class OrderHelper
    {
        #region [-ctor-]
        public OrderHelper()
        {

        }
        #endregion
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxRate { get; set; }
        public int Quantity { get; set; }
        public int Product_Ref { get; set; }
    }
}