using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Sample02.Models.Framework.Abstract;

namespace Sample02.Models.Framework.Base
{
    public class BaseRepository<K_DbContext, T_Entity, U_PrimaryKey, T_ViewHelper> : IUnitOfWork<K_DbContext, T_Entity, U_PrimaryKey, T_ViewHelper>
                                                                     where K_DbContext : DbContext
                                                                     where T_Entity : class
                                                                     where T_ViewHelper : class
    {
        #region [-ctor-]
        public BaseRepository(K_DbContext context)
        {
            Context = context;
            DbSet = context.Set<T_Entity>();
        }
        #endregion

        #region [- props -]
        public virtual K_DbContext Context { get; set; }
        public virtual DbSet<T_Entity> DbSet { get; set; }

        #endregion

        #region [-Methods-]

        #region [-Create(T_Entity entity)-]
        public virtual void Create(T_Entity entity)
        {
            using (Context)
            {
                DbSet.Add(entity);
                Context.SaveChanges();
            }
        }


        #endregion

        #region [-Update(T_Entity entity)-]
        public virtual void Update(T_Entity entity)
        {
            using (Context)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }
        #endregion

        #region [-Delete(U_PrimaryKey id)-]
        public virtual void Delete(U_PrimaryKey id)
        {
            using (Context)
            {
                var entityToDelete = DbSet.Find(id);
                DbSet.Remove(entityToDelete);
                Context.SaveChanges();
            }
        }
        #endregion

        #region [-Delete(T_Entity entity)-]
        public virtual void Delete(T_Entity entity)
        {
            using (Context)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                DbSet.Remove(entity);
                Context.SaveChanges();
            }
        }


        #endregion

        #region [- Select() -]
        public virtual List<T_Entity> Select()
        {
            using (Context)
            {
                var q = DbSet.Select(e => e).ToList();
                return q;
            }
        }
        #endregion

        #region [-SelectBySP(string sqlQuery, object[] parameters)-]
        public virtual List<T_ViewHelper> SelectBySP(string sqlQuery, object[] parameters)
        {
            using (Context)
            {
                try
                {
                    List<T_ViewHelper> list_ViewHelper = new List<T_ViewHelper>();
                    if(parameters == null)
                    {
                        list_ViewHelper = Context.Database.SqlQuery<T_ViewHelper>
                            (sqlQuery).ToList();
                    }
                    else
                    {
                        list_ViewHelper = Context.Database.SqlQuery<T_ViewHelper>(sqlQuery, parameters).ToList();
                    }
                    return list_ViewHelper;
                }
                catch (Exception)
                {
                    
                    throw;
                }
                finally
                {
                    Dispose();
                }

            }
        }
        #endregion

        #region [-CrudBySP(string sqlQuery, object[] parameters)-]
        public virtual void CrudBySP(string sqlQuery, object[] parameters)
        {
            try
            {
                Context.Database.ExecuteSqlCommand(sqlQuery, parameters);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        } 
        #endregion

        #region [-FindById(U_PrimaryKey id)-]
        public virtual T_Entity FindById(U_PrimaryKey id)
        {
            using (Context)
            {
                var r = DbSet.Select(e => e).FirstOrDefault();
                return r;
            }
        }
        #endregion

        #endregion

        #region [-SaveChanges()-]
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        #endregion

                #region [-Dispose()-]
        public void Dispose()
        {
            Context.Dispose();
        } 
        #endregion




    }
}