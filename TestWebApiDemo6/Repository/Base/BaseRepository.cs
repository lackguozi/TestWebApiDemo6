using SqlSugar;
using System.Linq.Expressions;
using System.Reflection;
using TestWebApiDemo6.Interface;
using TestWebApiDemo6.UnitofWork;

namespace TestWebApiDemo6.Resposity
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where  TEntity:class ,new()
    {
        private readonly IUnitOfWorkManger unitOfWork;
        private readonly SqlSugarScope dbBase;
        public ISqlSugarClient Db => db;
        public BaseRepository(IUnitOfWorkManger unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            dbBase = unitOfWork.GetDbClient();
        }
        private ISqlSugarClient db
        {
            get
            {
                ISqlSugarClient client = dbBase;
                var tenantAttr = typeof(TEntity).GetCustomAttribute<TenantAttribute>();
                if(tenantAttr != null)
                {
                    client = dbBase.GetConnectionScope(tenantAttr.configId.ToString().ToLower());
                    return client;
                }
               
                return client;
            }
        }
        public T GetSingleByIdFirstRedis<T>(dynamic id) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T GetSingleFirstRedis<T>(Expression<Func<T, bool>> lambda) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertRange(List<TEntity> entitys)
        {
            throw new NotImplementedException();
        }
    }
}
