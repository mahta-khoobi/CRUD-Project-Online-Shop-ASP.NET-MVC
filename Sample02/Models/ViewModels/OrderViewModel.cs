using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Sample02.Models.ViewModels
{
    public class OrderViewModel
    {
        #region [-ctor-]
        public OrderViewModel()
        {
            Ref_OrderCrud = new DomainModels.POCO.OrderCrud();
        }
        #endregion

        #region [-props for class-]
        public Models.DomainModels.POCO.OrderCrud Ref_OrderCrud { get; set; }
        public Models.DomainModels.DTO.EF.OrderMaster Ref_OrderMaster { get; set; }
        #endregion

        #region [-props for model-]
        public int Id { get; set; }
        public int OrderCode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Customer_Ref { get; set; }
       // public int CustomerCode { get; set; }
        public virtual ICollection<Models.DomainModels.DTO.EF.OrderDetails> OrderDetails { get; set; }
        #endregion

        #region [-FillGrid()-]
        public dynamic FillGrid()
        {
            return Ref_OrderCrud.SelectAll();
        }
        #endregion

        #region [-Save(Models.DomainModels.DTO.EF.OrderMaster ref_OrderMaster, ICollection<Models.DomainModels.DTO.EF.OrderDetails> orderDetails)-]
        public void Save(Models.DomainModels.DTO.EF.OrderMaster ref_OrderMaster, List<Models.DomainModels.DTO.Helper.OrderHelper> orderDetails)
        {
            Ref_OrderCrud.Insert(ref_OrderMaster, orderDetails);
        }
        #endregion

        #region [-Delete(int id)-]
        public void Delete(int id)
        {
            
            Ref_OrderCrud.Remove(id);
        } 
        #endregion

    }
}