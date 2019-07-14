using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample02.Models.Framework.Abstract
{
    public interface IRepository <K_DBContext, T_Entity, U_PrimaryKey,T_GetHelper> 
                                                             where T_Entity : class
                                                             where K_DBContext : DbContext
                                                             where T_GetHelper : class

    {
      
            K_DBContext Context { get; set; }
            DbSet<T_Entity> DbSet { get; set; }

            void Create(T_Entity entity);
            void Update(T_Entity entity);
            void Delete(U_PrimaryKey id);
            void Delete(T_Entity entity);
            List<T_Entity> Select();

            List<T_GetHelper> SelectBySP(string sqlQuery, object[] parameters);
            void CrudBySP(string sqlQuery, object[] parameters);

            T_Entity FindById(U_PrimaryKey id);
        }
    }

