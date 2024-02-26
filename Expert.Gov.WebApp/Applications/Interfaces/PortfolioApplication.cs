using Expert.Gov.Core.Models.TrabalhosRealizados;
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
                IdTrabalho = portfolioViewModel.IdTrabalho,
                Descricao = portfolioViewModel.Descricao,
                Resumo = portfolioViewModel.Resumo,
                DataHora = portfolioViewModel.DataHora,
                Local = portfolioViewModel.Local                
            };


            if(await _portfolioService.IncluirPortfolio(obj))
            {
                await this.IncluirAnexosPortfolio(portfolioViewModel.Anexos, obj.IdTrabalho);
                return true;
            }
            return false;
        }
    }
}
