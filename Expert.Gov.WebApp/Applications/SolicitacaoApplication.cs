using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Models.TrabalhosRealizados;
using Expert.Gov.Core.Services;
using Expert.Gov.Core.Services.Interfaces;
using Expert.Gov.WebApp.Applications.Interfaces;
using Expert.Gov.WebApp.Models;

namespace Expert.Gov.WebApp.Applications
{
    public class SolicitacaoApplication : ISolicitacaoApplication
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public SolicitacaoApplication(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }

        public async Task<bool> InserirSolicitacao(SolicitacaoViewModel solicitacaoViewModel)
        {
            var obj = new Solicitacao()
            {
                Id_Solicitacao = solicitacaoViewModel.Id_Solicitacao,
                Nome = solicitacaoViewModel.Nome,
                Celular = solicitacaoViewModel.Celular,
                Email = solicitacaoViewModel.Email,
                Endereco_solicitacao = solicitacaoViewModel.Endereco_solicitacao,
                Numero_solicitacao = solicitacaoViewModel.Numero_solicitacao,
                Cep_solicitacao = solicitacaoViewModel.Cep_solicitacao,
                Descricao_Titulo = solicitacaoViewModel.Descricao_Titulo,
                Descricao_Sugestao_Melhoria = solicitacaoViewModel.Descricao_Sugestao_Melhoria,
                
            };


            if (await _solicitacaoService.InserirSolicitacao(obj))
            {
                await this.IncluirAnexoSolicitacao(solicitacaoViewModel.Anexos, obj.Id_Solicitacao);
                return true;
            }
            return false;
        }

        public async Task<bool> AtualizarSolicitacao(Solicitacao solicitacao)
        {
            return await _solicitacaoService.AtualizarSolicitacao(solicitacao);
        }

        public async Task<IEnumerable<Solicitacao>> ObterTodasSolicitacaoes(Solicitacao solicitacao)
        {
            return await _solicitacaoService.ObterTodasSolicitacaoes(solicitacao);
        }
        public async Task<bool> ExcluirAnexo(long Id_solicitacao)
        {
            return await _solicitacaoService.ExcluirAnexo(Id_solicitacao);
        }
        public async Task<bool> ExcluirSolicitacao(long Id_solicitacao)
        {
            await ExcluirAnexo(Id_solicitacao);
            return await _solicitacaoService.ExcluirSolicitacao(Id_solicitacao);
        }
  
        public async Task IncluirAnexoSolicitacao(List<IFormFile> anexos, long  idSolicitacao)
        {
            if (anexos == null)
                return;

            ICollection<AnexoSolicitacao> anexosSolicitacao = new List<AnexoSolicitacao>();

            foreach (IFormFile anex in anexos)
            {
                AnexoSolicitacao obj = new AnexoSolicitacao(idSolicitacao);
                var extension = anex.FileName.Substring(anex.FileName.IndexOf('.'));

                using (MemoryStream ms = new MemoryStream())
                {
                    await anex.CopyToAsync(ms);
                    obj.InformarExtensao(extension);
                    obj.InformarAnexoBase64(Convert.ToBase64String(ms.ToArray()));

                    anexosSolicitacao.Add(obj);
                }


                await _solicitacaoService.IncluirAnexoSolicitacao(obj);
            }
        }


       public Task<IEnumerable<Solicitacao>> ConsultarSolicitacoes()
        { 
            throw new NotImplementedException();
        }

       
    }
}
