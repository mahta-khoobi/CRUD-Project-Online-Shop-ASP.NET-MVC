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
        public void Insert(DomainModels.DTO.EF.OrderMaster ref_OrderMaster, ICollection<Models.DomainModels.DTO.EF.OrderDetails> ref_OrderDetails)
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
                    orderDetails.Value = ref_OrderDetails;
                    orderDetails.TypeName = "dbo.udt_OrderDetailsList";

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
        }
        #endregion


    }
