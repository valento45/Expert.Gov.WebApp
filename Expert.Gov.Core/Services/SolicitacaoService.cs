using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Repositorys;
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

        public async Task<bool> InserirSolicitacao(Solicitacao solicitacao)
        {
            return await _solicitacaoRepository.InserirSolicitacao(solicitacao);
        }
        public async Task<bool> IncluirAnexoSolicitacao(AnexoSolicitacao anexo)
        {
            return await _solicitacaoRepository.IncluirAnexoSolicitacao(anexo);
        }

        public async Task<bool> AtualizarSolicitacao(Solicitacao solicitacao)
        {
            return await _solicitacaoRepository.AtualizarSolicitacao(solicitacao);
        }

        public async Task<IEnumerable<Solicitacao>> ObterTodasSolicitacaoes(Solicitacao solicitacao)
        {
            return await _solicitacaoRepository.ObterTodasSolicitacaoes(solicitacao);
        }

        public async Task<bool> ExcluirAnexo(long Id_Solicitacao)
        {
            return await _solicitacaoRepository.ExcluirAnexo(Id_Solicitacao);
        }

        public async Task<bool> ExcluirSolicitacao(long Id_Solicitacao)
        {
            return await _solicitacaoRepository.ExcluirSolicitacao(Id_Solicitacao);
        }

        public async Task<Solicitacao> GetById(long id)
        {
            return await _solicitacaoRepository.GetById(id);
        }

        public async Task<IEnumerable<AnexoSolicitacao>> ObterAnexos(long idSolicitacao)
        {
            return await _solicitacaoRepository.ObterAnexos(idSolicitacao);
        }
    }
}
