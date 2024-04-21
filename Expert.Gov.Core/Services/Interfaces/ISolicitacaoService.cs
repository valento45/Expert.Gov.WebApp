using Expert.Gov.Core.Models.SolicitacaoSugestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Services.Interfaces
{
    public interface ISolicitacaoService
    {
        Task<bool> InserirSolicitacao(Solicitacao solicitacao);
        Task<bool> AtualizarSolicitacao(Solicitacao solicitacao);
        Task<bool> IncluirAnexoSolicitacao(AnexoSolicitacao anexo);
        Task<IEnumerable<Solicitacao>> ObterTodasSolicitacaoes(Solicitacao solicitacao);
        Task<bool> ExcluirSolicitacao(long Id_Solicitacao);

        Task<bool> ExcluirAnexo(long Id_Solicitacao);
        Task<IEnumerable<Solicitacao>> ConsultarSolicitacoes();
    }
}
