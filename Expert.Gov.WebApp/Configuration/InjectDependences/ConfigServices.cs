using Expert.Gov.Core.Repositorys.Interfaces;
using Expert.Gov.Core.Repositorys;
using Expert.Gov.Core.Services.Interfaces;
using Expert.Gov.Core.Services;

namespace Expert.Gov.WebApp.Configuration.InjectDependences
{
    public static class ConfigServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISolicitacaoService, SolicitacaoService>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
        }
    }
}
