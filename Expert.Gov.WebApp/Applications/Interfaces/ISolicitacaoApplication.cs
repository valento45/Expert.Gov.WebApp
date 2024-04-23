using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.WebApp.Models;

namespace Expert.Gov.WebApp.Applications.Interfaces
{
    public interface ISolicitacaoApplication
    {

        Task<bool> InserirSolicitacao(SolicitacaoViewModel solicitacaoViewModel);
        Task IncluirAnexoSolicitacao(List<IFormFile> anexos, long idSolicitacao);
        Task<bool> AtualizarSolicitacao(Solicitacao solicitacao);

        Task<IEnumerable<Solicitacao>> ObterTodasSolicitacaoes(Solicitacao solicitacao);
        Task<bool> ExcluirAnexo(long Id_solicitacao);
        Task<bool> ExcluirSolicitacao(long Id_solicitacao);
        Task<Solicitacao?> GetById(long id);

    }
}
