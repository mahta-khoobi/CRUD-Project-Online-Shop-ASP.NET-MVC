using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample02.Models.Framework.Abstract
{
    public interface IUnitOfWork<K_DbContext, T_Entity, U_PrimaryKey, T_ViewHelper> : IRepository<K_DbContext, T_Entity, U_PrimaryKey,T_ViewHelper>, IDisposable
                                                                         where K_DbContext : DbContext
                                                                         where T_Entity : class 
                                                                         where T_ViewHelper : class
    {
        int SaveChanges();
    }
}
