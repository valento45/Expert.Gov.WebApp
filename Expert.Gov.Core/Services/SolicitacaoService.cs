using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Repositorys.Interfaces;
using Expert.Gov.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public SolicitacaoService(ISolicitacaoRepository solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }
        public async Task<bool> IncluirAnexo(AnexoSolicitacao anexoSolicitacao)
        {
            return await _solicitacaoRepository.IncluirAnexo(anexoSolicitacao);
        }

        public async Task<bool> Atualizar(Solicitacao solicitacao)
        {
            return await _solicitacaoRepository.Atualizar(solicitacao);
        }

        public async Task<IEnumerable<Solicitacao>> ConsultarSolicitacoes()
        {
            return await _solicitacaoRepository.ConsultarSolicitacoes();
        }

        public async Task<bool> Excluir(Solicitacao solicitacao)
        {
            return await _solicitacaoRepository.Excluir(solicitacao);
        }

        public async Task<bool> Inserir(Solicitacao solicitacao)
        {
            return await _solicitacaoRepository.Inserir(solicitacao);
        }
    }
}
