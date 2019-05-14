﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample02.Models.DomainModels.POCO
{
    public class ProductCategoryCrud
    {
        #region [-ctor-]
        public ProductCategoryCrud()
        {

        }
        #endregion
        #region [-Insert(DomainModels.DTO.EF.ProductCategory ref_ProductCategory)-]
        public void Insert(DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {

                    context.ProductCategory.Add(ref_ProductCategory);
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

        //other way is using list
        #region [-SelectAll()-]
        public List<Models.DomainModels.DTO.EF.ProductCategory> SelectAll()
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {

                try
                {
                    var q = context.usp_ProductCategory_Select().ToList();

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

        #region [-Remove(DomainModels.DTO.EF.ProductCategory ref_ProductCategory)-]
        public void Remove(DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    var itemToRemove = context.ProductCategory.SingleOrDefault(x => x.Id == ref_ProductCategory.Id);
                    if (itemToRemove != null)
                    {
                        context.ProductCategory.Remove(itemToRemove);
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

        #region [-Update(DomainModels.DTO.EF.ProductCategory ref_ProductCategory)-]
        public void Update(DomainModels.DTO.EF.ProductCategory ref_ProductCategory)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    context.Entry(ref_ProductCategory).State = EntityState.Modified;
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
        public Models.DomainModels.DTO.EF.ProductCategory FindRecord(int? id)
        {
            using (var context = new DomainModels.DTO.EF.OnlineShopEntities())
            {
                try
                {
                    var productCategory = context.ProductCategory.Find(id);
                    return productCategory;
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
