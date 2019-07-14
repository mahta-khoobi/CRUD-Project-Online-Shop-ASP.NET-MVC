using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample02.Models.Framework.Base
{
    public class UnitOfWork<K_DbContext, T_Entity, U_PrimaryKey, T_ViewHelper>
                                                                 where K_DbContext : DbContext
                                                                 where T_Entity : class
                                                                 where T_ViewHelper : class

    {
        //IUnitOfWork aggregated
        #region [- ctor -] 
        public UnitOfWork(Abstract.IUnitOfWork<K_DbContext, T_Entity, U_PrimaryKey,T_ViewHelper> ref_IUnitOfWork)
        {
            Ref_IUnitOfWork = ref_IUnitOfWork;
        }
        #endregion
        public Models.Framework.Abstract.IUnitOfWork<K_DbContext, T_Entity, U_PrimaryKey,T_ViewHelper> Ref_IUnitOfWork { get; set; }
    }
}