using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample02.Models.Framework.Abstract
{
    public interface IUnitOfWork<K_DbContext, T_Entity, U_PrimaryKey> : IRepository<K_DbContext, T_Entity, U_PrimaryKey>, IDisposable
                                                                         where K_DbContext : DbContext
                                                                         where T_Entity : class
    {
        void Save();
    }
}
