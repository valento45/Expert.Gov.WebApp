using Expert.Gov.WebApp.Models;

namespace Expert.Gov.WebApp.Applications.Interfaces
{
    public interface IPortfolioApplication
    {
        Task<bool> IncluirPortfolio(PortfolioViewModel portfolioViewModel);
        Task IncluirAnexosPortfolio(List<IFormFile> anexos, long idPortfolio);
    }
}
