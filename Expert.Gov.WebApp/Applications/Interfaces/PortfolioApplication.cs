//using AspNetCore;
using Expert.Gov.Core.Models.TrabalhosRealizados;
using Expert.Gov.Core.Services;
using Expert.Gov.Core.Services.Interfaces;
using Expert.Gov.WebApp.Models;

namespace Expert.Gov.WebApp.Applications.Interfaces
{
    public class PortfolioApplication : IPortfolioApplication
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioApplication(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task IncluirAnexosPortfolio(List<IFormFile> anexos, long idPortfolio)
        {
            if (anexos == null)
                return;

            ICollection<AnexoTrabalhoRealizado> anexosPortfolio = new List<AnexoTrabalhoRealizado>();

            foreach (IFormFile anex in anexos)
            {
                AnexoTrabalhoRealizado obj = new AnexoTrabalhoRealizado(idPortfolio);
                var extension = anex.FileName.Substring(anex.FileName.IndexOf('.'));

                using (MemoryStream ms = new MemoryStream())
                {
                    await anex.CopyToAsync(ms);
                    obj.InformarExtensao(extension);
                    obj.InformarAnexoBase64(Convert.ToBase64String(ms.ToArray()));

                    anexosPortfolio.Add(obj);
                }

                await _portfolioService.IncluirAnexoPortfolio(obj);
            }

        }

        public async Task<bool> IncluirPortfolio(PortfolioViewModel portfolioViewModel)
        {

            var obj = new TrabalhoRealizado()
            {
                Id_Portfolio = portfolioViewModel.IdTrabalho,
                Descricao = portfolioViewModel.Descricao,
                Resumo = portfolioViewModel.Resumo,
                Data_Hora = portfolioViewModel.DataHora,
                Endereco = portfolioViewModel.Local
            };


            if (await _portfolioService.IncluirPortfolio(obj))
            {
                await this.IncluirAnexosPortfolio(portfolioViewModel.Anexos, obj.Id_Portfolio);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TrabalhoRealizado>> ObterTodosPortfolios(TrabalhoRealizado trabalhoRealizado)
        {
            var listaTrabalhos = await _portfolioService.ObterTodosPortfolios(trabalhoRealizado);

            foreach (var trabRealizado in listaTrabalhos)
            {
                var anexos = await _portfolioService.ObterTodosAnexosByPortfolio(trabRealizado.Id_Portfolio);

                trabRealizado.Imagens = anexos.ToList();
            }

            return listaTrabalhos;
        }
        public async Task<bool> ExcluirAnexo(long Id_Portfolio)
        {
            return await _portfolioService.ExcluirAnexo(Id_Portfolio);
        }
        public async Task<bool> ExcluirTrabalho(long Id_Portfolio)
        {
            await ExcluirAnexo(Id_Portfolio);
            return await _portfolioService.ExcluirTrabalho(Id_Portfolio);
        }
        public async Task<TrabalhoRealizado> ObterPorId(long Id_Portfolio)
        {

            return await _portfolioService.ObterPorId(Id_Portfolio);
        }
        public async Task<bool> AtualizarPortfolio(PortfolioViewModel portfolioViewModel)
        {
            TrabalhoRealizado trabalhoRealizado = new TrabalhoRealizado();

            trabalhoRealizado.Id_Portfolio = portfolioViewModel.Id_Portfolio;
            trabalhoRealizado.Descricao = portfolioViewModel.Descricao;
            trabalhoRealizado.Data_Hora = portfolioViewModel.DataHora;
            trabalhoRealizado.Resumo = portfolioViewModel.Resumo;
            trabalhoRealizado.Endereco = portfolioViewModel.Local;

            if (await _portfolioService.AtualizarPortfolio(trabalhoRealizado))
            {

                if (portfolioViewModel.Anexos?.Any() ?? false)
                {
                    await this.ExcluirAnexo(portfolioViewModel.Id_Portfolio);
                    await this.IncluirAnexosPortfolio(portfolioViewModel.Anexos, portfolioViewModel.Id_Portfolio);
                }

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<AnexoTrabalhoRealizado>> ObterTodosAnexosByPortfolio(long Id_Portfolio)
        {
            return await _portfolioService.ObterTodosAnexosByPortfolio(Id_Portfolio);
        }
    }
}
