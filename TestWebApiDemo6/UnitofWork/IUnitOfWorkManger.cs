using SqlSugar;

namespace TestWebApiDemo6.UnitofWork
{
    public interface IUnitOfWorkManger
    {
        void BeginTran();
        void CommitTran();
        void RollbackTran();
        SqlSugarScope GetDbClient();
        int TranCount { get; }
        UnitOfWork CreateUnitOfWork();
    }
}
