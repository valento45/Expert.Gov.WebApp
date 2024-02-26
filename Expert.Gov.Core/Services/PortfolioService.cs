using Expert.Gov.Core.Models.TrabalhosRealizados;
using Expert.Gov.Core.Repositorys.Interfaces;
using Expert.Gov.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<bool> IncluirPortfolio(TrabalhoRealizado trabalhoRealizado)
        {
            return await _portfolioRepository.IncluirPortfolio(trabalhoRealizado);
        }


        public async Task<bool> IncluirAnexoPortfolio(AnexoTrabalhoRealizado anexo)
        {
            return await _portfolioRepository.IncluirAnexoPortfolio(anexo);
        }



        public Task<bool> AtualizarPortfolio(TrabalhoRealizado trabalhoRealizado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirPortfolio(long idPortfolio)
        {
            throw new NotImplementedException();
        }    

       

        public IEnumerable<TrabalhoRealizado> ObterPortfoliosVitrine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrabalhoRealizado> ObterTodosPortfolios()
        {
            throw new NotImplementedException();
        }
    }
}
