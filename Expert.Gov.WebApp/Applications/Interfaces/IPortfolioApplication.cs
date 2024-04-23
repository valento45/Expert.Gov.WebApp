using Expert.Gov.Core.Models.TrabalhosRealizados;
using Expert.Gov.WebApp.Models;

namespace Expert.Gov.WebApp.Applications.Interfaces
{
    public interface IPortfolioApplication
    {
        Task<bool> IncluirPortfolio(PortfolioViewModel portfolioViewModel);
        Task IncluirAnexosPortfolio(List<IFormFile> anexos, long idPortfolio);
        Task<IEnumerable<TrabalhoRealizado>> ObterTodosPortfolios(TrabalhoRealizado trabalhoRealizado);
        Task<bool> ExcluirAnexo(long Id_Portfolio);
        Task<bool> ExcluirTrabalho(long Id_Portfolio);
        Task <TrabalhoRealizado> ObterPorId(long Id_Portfolio);
        Task<bool> AtualizarPortfolio(PortfolioViewModel trabalhoRealizado);
        Task<IEnumerable<AnexoTrabalhoRealizado>> ObterTodosAnexosByPortfolio(long Id_Portfolio);
    }
}
