using Expert.Gov.Core.Models.TrabalhosRealizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Services.Interfaces
{
    public interface IPortfolioService
    {
        //IEnumerable<TrabalhoRealizado> ObterTodosPortfolios();
        IEnumerable<TrabalhoRealizado> ObterPortfoliosVitrine();


        Task<IEnumerable<AnexoTrabalhoRealizado>> ObterTodosAnexosByPortfolio(long Id_Portfolio);
        Task<bool> IncluirPortfolio(TrabalhoRealizado trabalhoRealizado);
        Task<bool> IncluirAnexoPortfolio(AnexoTrabalhoRealizado anexo);
        Task<bool> AtualizarPortfolio(TrabalhoRealizado trabalhoRealizado);
        Task<bool> ExcluirPortfolio(long idPortfolio);
        Task <IEnumerable<TrabalhoRealizado>> ObterTodosPortfolios(TrabalhoRealizado trabalhoRealizado);

        Task<bool> ExcluirAnexo(long Id_Portfolio);
        Task<bool> ExcluirTrabalho(long Id_Portfolio);
        Task <TrabalhoRealizado> ObterPorId(long Id_Portfolio);
        

    }
}
