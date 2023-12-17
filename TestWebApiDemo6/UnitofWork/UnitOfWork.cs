using Microsoft.Extensions.Logging;
using SqlSugar;

namespace TestWebApiDemo6.UnitofWork
{
    public class UnitOfWork : IDisposable
    {
        public ISqlSugarClient Db { get;internal set; }
        public ITenant Tenant { get; internal set; }
        /// <summary>
        /// 是否是事务
        /// </summary>
        public bool IsTran;
        public bool IsCommit;
        public bool IsClose;
        public bool Commit()
        {
            if(IsTran && !IsCommit)
            {
                Tenant.CommitTran();
                IsCommit = true;
            }
            if (Db.Ado.Transaction == null && !IsClose)
            {
                Db.Close();
                IsClose = true;
            }                                 
            return IsCommit;
        }
        public void Dispose()
        {
            if (IsTran && !IsCommit)
            {
                //Logger.LogDebug("UnitOfWork RollbackTran");
                Tenant.RollbackTran();
            }

            if (Db.Ado.Transaction != null || IsClose)
                return;
            Db.Close();
        }
    }
}
