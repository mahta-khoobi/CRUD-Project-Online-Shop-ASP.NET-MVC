using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Sample02.Models.Framework.Abstract;

namespace Sample02.Models.Framework.Base
{
    public class BaseRepository<K_DbContext, T_Entity, U_PrimaryKey> : Abstract.IUnitOfWork<K_DbContext, T_Entity, U_PrimaryKey>
                                                                     where K_DbContext : DbContext
                                                                     where T_Entity : class
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

        #region [-Refresh()-]
        public virtual dynamic Refresh()
        {
            using (Context)
            {
                var q = DbSet.Select(e => e).ToList();
                return q;
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

        public void Dispose()
        {
            throw new NotImplementedException();
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

        #region [-Save()-]
        public void Save()
        {
            Context.SaveChanges();
        } 
        #endregion

   


    }
}