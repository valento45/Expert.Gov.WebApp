using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Models.TrabalhosRealizados;
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

        public async Task<bool> InserirSolicitacao(Solicitacao solicitacao)
        {
            string query = "insert into solicitacao_tb" +
                " (nome, celular, email, endereco_solicitacao, numero_solicitacao, cep_solicitacao , descricao_titulo, descricao_sugestao_melhoria)" +
                " values (@nome, @celular, @email, @endereco_solicitacao, @numero_solicitacao, @cep_solicitacao , @descricao_titulo, @descricao_sugestao_melhoria) returning id_solicitacao;";


            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"nome", solicitacao.Nome);
            cmd.Parameters.AddWithValue(@"celular", solicitacao.Celular);
            cmd.Parameters.AddWithValue(@"email", solicitacao.Email);
            cmd.Parameters.AddWithValue(@"endereco_solicitacao", solicitacao.Endereco_solicitacao ?? "");
            cmd.Parameters.AddWithValue(@"numero_solicitacao",solicitacao.Numero_solicitacao);
            cmd.Parameters.AddWithValue(@"cep_solicitacao", solicitacao.Cep_solicitacao ?? "");
            cmd.Parameters.AddWithValue(@"descricao_titulo", solicitacao.Descricao_Titulo ?? "");
            cmd.Parameters.AddWithValue(@"descricao_sugestao_melhoria", solicitacao.Descricao_Sugestao_Melhoria ?? "");

            var result = await base.ExecuteScalarAsync(cmd);

            if (result != null)
            {
                solicitacao.Id_Solicitacao = long.Parse(result.ToString());
            }

            return solicitacao.Id_Solicitacao > 0;

        }
        public async Task<bool> IncluirAnexoSolicitacao(AnexoSolicitacao anexo)
        {
            string query = "insert into anexo_solicitacao_tb (id_solicitacao, anexo_base64, extensao_arquivo)" +
          " values (@id_solicitacao, @anexo_base64, @extensao_arquivo)";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"id_solicitacao", anexo.Id_Solicitacao);
            cmd.Parameters.AddWithValue(@"anexo_base64", anexo.Anexo_Base64);
            cmd.Parameters.AddWithValue(@"extensao_arquivo", anexo.Extensao_Arquivo);


            var result = await base.ExecuteCommand(cmd);
            return result;
        }
        public async Task<bool> AtualizarSolicitacao(Solicitacao solicitacao)
        {
            string query = "update solicitacao_tb set nome = @nome, celular = @celular, email = @email," +
                " endereco_solicitacao = @endereco_solicitacao, numero_solicitacao = @numero_solicitacao," +
                " cep_solicitacao = @cep_solicitacao, descricao_titulo = @descricao_titulo," +
                " descricao_sugestao_melhoria = @descricao_sugestao_melhoria where id_Solicitacao = @id_Solicitacao";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"id_Solicitacao", solicitacao.Id_Solicitacao);
            cmd.Parameters.AddWithValue(@"nome", solicitacao.Nome);
            cmd.Parameters.AddWithValue(@"celular", solicitacao.Celular);
            cmd.Parameters.AddWithValue(@"email", solicitacao.Email);
            cmd.Parameters.AddWithValue(@"endereco_solicitacao", solicitacao.ObterEnderecoFormatado());
            cmd.Parameters.AddWithValue(@"numero_solicitacao", solicitacao.ObterEnderecoFormatado());
            cmd.Parameters.AddWithValue(@"cep_solicitacao", solicitacao.ObterEnderecoFormatado());
            cmd.Parameters.AddWithValue(@"descricao_titulo", solicitacao.Descricao_Titulo);
            cmd.Parameters.AddWithValue(@"descricao_sugestao_melhoria", solicitacao.Descricao_Sugestao_Melhoria);

            return await base.ExecuteCommand(cmd);
        }

        public async Task<bool> ExcluirAnexo(long Id_solicitacao)
        {
            string query = " delete from anexo_solicitacao_tb where id_solicitacao = " + Id_solicitacao;
            var result = await this.ExecuteAsync(query);
            return result;
        }
        public async Task<bool> ExcluirSolicitacao(long Id_solicitacao)
        {
            string query = " delete from solicitacao_tb where id_solicitacao = " + Id_solicitacao;

            var result = await this.ExecuteAsync(query);

            return result;
        }
      
        public async Task<IEnumerable<Solicitacao>> ObterTodasSolicitacaoes(Solicitacao solicitacao)
        {
            string query = "select * from  solicitacao_tb ";

            var result = await QueryAsync<Solicitacao>(query);

            return result;
        }

        public async Task<Solicitacao> GetById(long id)
        {
            string query = "select * from  solicitacao_tb where id_solicitacao = " + id;

            var result = await QueryAsync<Solicitacao>(query);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<AnexoSolicitacao>> ObterAnexos(long idSolicitacao)
        {
            string query = "select * from  anexo_solicitacao_tb where id_solicitacao = " + idSolicitacao;

            var result = await QueryAsync<AnexoSolicitacao>(query);

            return result;
        }
    }
}
