using Expert.Gov.Core.Models.TrabalhosRealizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Repositorys.Interfaces
{
    public interface IPortfolioRepository
    {

        IEnumerable<TrabalhoRealizado> ObterTodosPortfolios();
        IEnumerable<TrabalhoRealizado> ObterPortfoliosVitrine();



        Task<bool> IncluirPortfolio(TrabalhoRealizado trabalhoRealizado);
        Task<bool> IncluirAnexoPortfolio(AnexoTrabalhoRealizado anexo);
        Task<bool> AtualizarPortfolio(TrabalhoRealizado trabalhoRealizado);
        Task<bool> ExcluirPortfolio(long idPortfolio);


    }
}
