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

        #region [-Insert(DomainModels.DTO.EF.OrderMaster ref_OrderMaster,ICollection<Models.DomainModels.DTO.EF.OrderDetails> ref_OrderDetails)-]
        public void Insert(DomainModels.DTO.EF.OrderMaster ref_OrderMaster, List<Models.DomainModels.DTO.Helper.OrderHelper> ref_OrderDetails)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    #region [ADO]
                    // // ref_OrderDetails.ForEach(x => orderDetails.Rows.Add(x));    
                    // SqlConnection sqlconn = new SqlConnection(context.Database.Connection.ConnectionString);
                    // SqlCommand command = new SqlCommand("dbo.usp_OrderMasterDetails_Insert", sqlconn);
                    // command.CommandType = CommandType.StoredProcedure;
                    // command.Parameters.AddWithValue("@udt_orderDetailsList", ref_OrderDetails);
                    //// command.Parameters.AddWithValue("@idMaster",ref_OrderMaster.Id);
                    // command.Parameters.AddWithValue("@orderDate", ref_OrderMaster.OrderDate);
                    // command.Parameters.AddWithValue("@customer_Ref", ref_OrderMaster.Customer_Ref);

                    // sqlconn.Open();
                    // command.ExecuteNonQuery();
                    // context.SaveChanges();
                    // sqlconn.Close();
                    // context.SaveChanges(); 
                    #endregion

                    var orderDetails = new SqlParameter("@udt_orderDetailsList", SqlDbType.Structured);
                    // int[] marks = new int[5] { 99, 98, 92, 97, 18 };
                    DataTable table = new DataTable();
                    table.Columns.Add("UnitPrice", typeof(decimal));
                    table.Columns.Add("Discount", typeof(decimal));
                    table.Columns.Add("TaxRate", typeof(decimal));
                    table.Columns.Add("Quantity", typeof(int));
                    table.Columns.Add("Product_Ref", typeof(int));

                    // Here we add five DataRows.
                    foreach(Models.DomainModels.DTO.Helper.OrderHelper i in ref_OrderDetails)
                    {
                        table.Rows.Add(i);
                    }
                    orderDetails.Value = table;
                    orderDetails.TypeName = "dbo.udt_OrderDetailsList";

                    var orderDate = new SqlParameter("@orderDate", SqlDbType.DateTime);
                    orderDate.Value = DateTime.Now;

                    var orderCode = new SqlParameter("@orderCode", SqlDbType.Int);
                    orderCode.Value = 39;

                    var ref_Customer = new SqlParameter("@customer_Ref", SqlDbType.Int);
                    ref_Customer.Value = 11;


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
        }
        #endregion



    }
