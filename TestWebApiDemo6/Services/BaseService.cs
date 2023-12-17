using TestWebApiDemo6.Interface;

namespace TestWebApiDemo6.Services
{
    public class BaseService<TEntity> :IBaseService<TEntity> where TEntity : class, new()
    {

    }
}
