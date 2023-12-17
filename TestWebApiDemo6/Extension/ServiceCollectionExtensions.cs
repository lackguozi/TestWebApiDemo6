using System.Reflection;
using TestWebApiDemo6.Interface;
using TestWebApiDemo6.Model;

namespace TestWebApiDemo6.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void InitDbConnection(this ServiceCollection services,ConfigurationManager configuration)
        {

        }
        public static void AddCustomizeServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddModule(configuration);
            var serviceProvides = services.BuildServiceProvider();
            var ModuleInitializers = serviceProvides.GetServices<IModuleInitializer>();
            Console.WriteLine($"服务的数量{ModuleInitializers.Count()} 个");
            foreach (var moduleInitializer in ModuleInitializers)
            {
                moduleInitializer.ConfigurationServices(services, configuration);
            }
        }
        public static void AddModule(this IServiceCollection services, IConfiguration configuration)
        {
            var modules = configuration.GetSection("Modules").Get<List<ModuleInfo>>();
            foreach (var module in modules)
            {

                module.Assembly = Assembly.Load(new AssemblyName(module.Id));
                var types = module.Assembly.GetTypes().FirstOrDefault(a => typeof(IModuleInitializer).IsAssignableFrom(a) && typeof(IModuleInitializer) != a);
                if (types != null)
                {
                    services.AddSingleton(typeof(IModuleInitializer), types);
                }

            }
        }
    }
}
