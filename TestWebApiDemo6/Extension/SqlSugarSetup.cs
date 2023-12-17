using SqlSugar;
using TestWebApiDemo6.Model;

namespace TestWebApiDemo6.Extension
{
    public static class SqlSugarSetup
    {
        /// <summary>
        /// 添加sqlsugar使用
        /// </summary>
        /// <param name="services"></param>
        public static void AddSqlSugarSetup(this IServiceCollection services,ConfigurationManager configuration)
        {
            //获取数据库配置信息、
            var dbConfigs = configuration.GetSection("DbSetting").Get<List<DbConfig>>();
            
            var connectionConfigs = new List<ConnectionConfig>();
            dbConfigs.ForEach(a =>
            {
                var config = new ConnectionConfig()
                {
                    ConfigId = a.ConnId.ToLower(),
                    DbType = (DbType) a.DbType,
                    ConnectionString = a.Connection,
                    IsAutoCloseConnection = true,
                };
                if (a.Enabled)
                {
                    connectionConfigs.Add(config);
                }
                
            });
            Console.WriteLine(connectionConfigs.Count);
            //使用sqlsugar配置信息
            services.AddSingleton<ISqlSugarClient>(o =>
            {
                return new SqlSugarScope(connectionConfigs, db =>
                {
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        Console.WriteLine(sql, pars);//打印输出sql
                    };
                });
            });
        }
    }
}
