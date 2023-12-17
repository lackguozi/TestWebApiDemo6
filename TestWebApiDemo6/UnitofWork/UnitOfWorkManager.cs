using SqlSugar;

namespace TestWebApiDemo6.UnitofWork
{
    public class UnitOfWorkManager : IUnitOfWorkManger
    {
        private ISqlSugarClient sqlSugarClient;
        public UnitOfWorkManager(ISqlSugarClient sqlSugarClient)
        {
            tranCount = 0;
            this.sqlSugarClient = sqlSugarClient;
        }
        public SqlSugarScope GetDbClient()
        {
            return sqlSugarClient as SqlSugarScope;
        }
        private int tranCount { get; set; }
        public int TranCount => tranCount;

        public void BeginTran()
        {
            lock (this)
            {
                tranCount++;
                GetDbClient().BeginTran();
            }
        }

        public void CommitTran()
        {
            lock (this)
            {
                tranCount--;
                if (tranCount == 0)
                {
                    try
                    {
                        GetDbClient().CommitTran();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        GetDbClient().RollbackTran();
                    }
                }             
            }
        }

        public UnitOfWork CreateUnitOfWork()
        {
            var uow = new UnitOfWork();
            uow.Db = sqlSugarClient;
            uow.Tenant= sqlSugarClient.AsTenant();
            uow.IsTran = true;
            uow.Db.Ado.Open();
            uow.Tenant.BeginTran();

            return uow;
        }


        public void RollbackTran()
        {
            throw new NotImplementedException();
        }
    }
}
