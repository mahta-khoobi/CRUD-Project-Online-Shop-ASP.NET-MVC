using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sample02.Models.DomainModels.POCO
{
    public class OrderCrud
    {
        #region [-ctor-]
        public OrderCrud()
        {

        }
        #endregion

        #region [-SelectAll()-]
        public IEnumerable<Models.DomainModels.DTO.EF.usp_OrderMaster_Select_Result> SelectAll()
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {

                try
                {

                    context.Configuration.ProxyCreationEnabled = false;
                    var q = context.usp_OrderMaster_Select().ToList();
                    return q;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {

                }
            }
        }
        #endregion

        #region [-Insert(DomainModels.DTO.EF.OrderMaster ref_OrderMaster,List<Models.DomainModels.DTO.EF.OrderDetails> ref_OrderDetails)-]
        public void Insert(DomainModels.DTO.EF.OrderMaster ref_OrderMaster, List<Models.DomainModels.DTO.Helper.OrderHelper> ref_OrderDetails)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                { 

                    DataTable orderDetailsTable = new DataTable();
                    orderDetailsTable.Columns.Add("UnitPrice", typeof(decimal));
                    orderDetailsTable.Columns.Add("Discount", typeof(decimal));
                    orderDetailsTable.Columns.Add("TaxRate", typeof(decimal));
                    orderDetailsTable.Columns.Add("Quantity", typeof(Int32));
                    orderDetailsTable.Columns.Add("Product_Ref", typeof(Int32));
                    for (int i = 0; i < ref_OrderDetails.Count; i++)
                    {
                        orderDetailsTable.Rows.Add(Convert.ToDecimal(ref_OrderDetails[i].UnitPrice), Convert.ToDecimal(ref_OrderDetails[i].Discount), Convert.ToDecimal(ref_OrderDetails[i].TaxRate), Convert.ToInt32(ref_OrderDetails[i].Quantity), Convert.ToInt32(ref_OrderDetails[i].Product_Ref));
                    }
                    var orderDetails = new SqlParameter()
                    {
                        ParameterName = "@udt_orderDetailsList",
                        SqlDbType = SqlDbType.Structured,
                        Value = orderDetailsTable,
                        TypeName = "dbo.udt_OrderDetailsList"
                    };

                    var orderDate = new SqlParameter("@orderDate", SqlDbType.DateTime);
                    orderDate.Value = ref_OrderMaster.OrderDate;

                    var orderCode = new SqlParameter("@orderCode", SqlDbType.Int);
                    orderCode.Value = ref_OrderMaster.OrderCode;

                    var ref_Customer = new SqlParameter("@customer_Ref", SqlDbType.Int);
                    ref_Customer.Value = ref_OrderMaster.Customer_Ref;

                    context.Database.ExecuteSqlCommand("exec dbo.usp_OrderMasterDetails_Insert @orderCode,@udt_orderDetailsList,@orderDate,@customer_Ref",
                        orderCode, orderDetails, orderDate, ref_Customer);
                    context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [-Remove(int id)-]
        public void Remove(int id)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            
                try
                {
                    var i = context.OrderMaster.Where(p => p.Id == id).Select(p => p);
                    if (i != null)
                    {
                        
                        context.usp_OrderMasterDetails_Delete(id);
                        context.SaveChanges();
                    }
                }

                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }

                }
            }
        #endregion

        #region [-SelectOrderDetailsGivenOrdeMasterId(DomainModels.DTO.EF.OrderMaster ref_OrderMaster)-]
        public List<Models.DomainModels.DTO.EF.usp_GetOrderDetailsGivenOrderMasterId_Result> SelectOrderDetailsGivenOrdeMasterId(int id)
        {

            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    var q = context.usp_GetOrderDetailsGivenOrderMasterId(id).ToList();
                    return q;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {

                }
            }
        }
        #endregion

    }





}
