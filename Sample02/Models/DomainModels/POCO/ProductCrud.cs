using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample02.Models.DomainModels.POCO
{
    public class ProductCrud
    {
        #region [-ctor-]
        public ProductCrud()
        {

        }
        #endregion

        #region [-Insert(DomainModels.DTO.EF.Product ref_Product)-]
        public void Insert(DomainModels.DTO.EF.Product ref_Product)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {

                    context.Product.Add(ref_Product);
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

        #region [-SelectAll()-]
        public IEnumerable<Models.DomainModels.DTO.EF.Product> SelectAll()
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {

                try
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    var q = context.Product.ToList();

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

        #region [-Remove(DomainModels.DTO.EF.Product ref_Product)-]
        public void Remove(DomainModels.DTO.EF.Product ref_Product)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    var itemToRemove = context.Product.SingleOrDefault(x => x.Id == ref_Product.Id);
                    if (itemToRemove != null)
                    {
                        context.Product.Remove(itemToRemove);
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

        #region [-Update(DomainModels.DTO.EF.Product ref_Product)-]
        public void Update(DomainModels.DTO.EF.Product ref_Product)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    context.Entry(ref_Product).State = EntityState.Modified;
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

        #region [- FindRecord(int? id) -]
        public Models.DomainModels.DTO.EF.Product FindRecord(int? id)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    var product = context.Product.Find(id);
                    return product;
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
}