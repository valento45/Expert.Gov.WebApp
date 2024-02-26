using Expert.Gov.Core.Repositorys.Interfaces;
using Expert.Gov.Core.Repositorys;
using Expert.Gov.WebApp.Applications.Interfaces;

namespace Expert.Gov.WebApp.Configuration.InjectDependences
{
    public static class ConfigApplication
    {
        public static void AddApplications(this IServiceCollection services)
        {
            services.AddTransient<IPortfolioApplication, PortfolioApplication>();
        }
    }
}
