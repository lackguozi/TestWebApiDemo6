using SqlSugar;
using System.Linq.Expressions;

namespace TestWebApiDemo6.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ISqlSugarClient Db { get; }
        Task<int> Insert(TEntity entity);
        Task<int> InsertRange(List<TEntity> entitys);
    }
    public interface IRespostityFirstUseRedis<TEntity> where TEntity : class
    {
        Task<TEntity> GetSingleByIdFirstRedis(dynamic id);
        Task<TEntity> GetSingleFirstRedis(Expression<Func<TEntity, bool>> lambda);
    }


}
