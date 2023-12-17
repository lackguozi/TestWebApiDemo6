using System.IdentityModel.Tokens.Jwt;

namespace TestWebApiDemo6.Interface
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<JwtHelper>();
        }


    }
    public interface IModuleInitializer
    {
        void ConfigurationServices(IServiceCollection services, IConfiguration configuration);
    }
}
