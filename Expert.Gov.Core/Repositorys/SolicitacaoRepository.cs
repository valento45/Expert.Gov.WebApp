using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Repositorys.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Repositorys
{
    public class SolicitacaoRepository : RepositoryBase, ISolicitacaoRepository
    {
        public SolicitacaoRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public async Task<bool> Inserir(Solicitacao solicitacao)
        {
            string query = "insert into solicitacao_tb" +
                " (nome, celular, email, endereco_solicitacao, descricao_titulo, descricao_sugestao_melhoria)" +
                " values (@nome, @celular, @email, @endereco_solicitacao, @descricao_titulo, @descricao_sugestao_melhoria) returning id_solicitacao;";


            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"nome", solicitacao.Nome);
            cmd.Parameters.AddWithValue(@"celular", solicitacao.Celular);
            cmd.Parameters.AddWithValue(@"email", solicitacao.Email);
            cmd.Parameters.AddWithValue(@"endereco_solicitacao", solicitacao.ObterEnderecoFormatado());
            cmd.Parameters.AddWithValue(@"descricao_titulo", solicitacao.DescricaoProblema);
            cmd.Parameters.AddWithValue(@"descricao_sugestao_melhoria", solicitacao.DescricaoSugestaoMelhoria);

            var result = await this.ExecuteScalarAsync(cmd);

            if (result != null)
            {
                solicitacao.IdSolicitacao = int.Parse(result.ToString());

                foreach (var anex in solicitacao.Anexos)
                {
                    anex.IdSolicitacao = solicitacao.IdSolicitacao;

                    await this.IncluirAnexo(anex);
                }
                return true;
            }

            return false;

        }
        public Task<bool> Atualizar(Solicitacao solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Solicitacao>> ConsultarSolicitacoes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(Solicitacao solicitacao)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IncluirAnexo(AnexoSolicitacao anexoSolicitacao)
        {
            string query = "insert into anexos_solicitacao_tb (id_solicitacao, anexo_base64, tipo_anexo)" +
                $" values ({anexoSolicitacao.IdSolicitacao}, '{anexoSolicitacao.AnexoBase64}', '{anexoSolicitacao.TipoAnexo}')";

            return await this.ExecuteAsync(query);
        }
    }
}
