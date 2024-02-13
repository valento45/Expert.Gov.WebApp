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

        Task<bool> Inserir(Solicitacao solicitacao);
        Task<bool> Atualizar(Solicitacao solicitacao);
        Task<bool> Excluir(Solicitacao solicitacao);

        Task<bool> IncluirAnexo(AnexoSolicitacao anexoSolicitacao);


        Task<IEnumerable<Solicitacao>> ConsultarSolicitacoes();
    }
}
