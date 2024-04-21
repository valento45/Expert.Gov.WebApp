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



        public async Task<bool> AtualizarPortfolio(TrabalhoRealizado trabalhoRealizado)
        {
            return await _portfolioRepository.AtualizarPortfolio(trabalhoRealizado);
        }

        public Task<bool> ExcluirPortfolio(long idPortfolio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrabalhoRealizado> ObterPortfoliosVitrine()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrabalhoRealizado>> ObterTodosPortfolios(TrabalhoRealizado trabalhoRealizado)
        {
            return await _portfolioRepository.ObterTodosPortfolios(trabalhoRealizado);
        }
        public async Task<bool> ExcluirAnexo(long Id_Portfolio)
        {
            return await _portfolioRepository.ExcluirAnexo(Id_Portfolio);
        }

        public async Task<bool> ExcluirTrabalho(long Id_Portfolio)
        {
            return await _portfolioRepository.ExcluirTrabalho(Id_Portfolio);
        }
        public async Task<TrabalhoRealizado> ObterPorId(long Id_Portfolio)
        {
            return await _portfolioRepository.ObterPorId(Id_Portfolio);
        }

        public async Task<IEnumerable<AnexoTrabalhoRealizado>> ObterTodosAnexosByPortfolio(long Id_Portfolio)
        {
            return await _portfolioRepository.ObterTodosAnexosByPortfolio(Id_Portfolio);
        }
    }
}
