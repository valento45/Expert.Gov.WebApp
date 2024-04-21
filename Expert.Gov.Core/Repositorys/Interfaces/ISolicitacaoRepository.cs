using Expert.Gov.Core.Models.SolicitacaoSugestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Repositorys.Interfaces
{
    public interface ISolicitacaoRepository
    {

        Task<bool> InserirSolicitacao(Solicitacao solicitacao);
        Task<bool> AtualizarSolicitacao(Solicitacao solicitacao);
        Task<bool> ExcluirAnexo(long Id_solicitacao);

        Task<bool> ExcluirSolicitacao(long Id_solicitacao);
        Task<bool> IncluirAnexoSolicitacao(AnexoSolicitacao anexo);  
        Task<IEnumerable<Solicitacao>> ObterTodasSolicitacaoes(Solicitacao solicitacao);
        Task<IEnumerable<Solicitacao>> ConsultarSolicitacoes();
    }
}
