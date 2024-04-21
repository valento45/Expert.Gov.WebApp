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
    public class PortfolioRepository : RepositoryBase, IPortfolioRepository
    {
        public PortfolioRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
        public async Task<bool> IncluirPortfolio(TrabalhoRealizado trabalhoRealizado)
        {
            string query = "insert into portfolio_tb(descricao, data_hora, resumo, endereco, ordem_apresentacao)" +
                " values (@descricao, @data_hora, @resumo, @endereco, @ordem_apresentacao) returning id_portfolio";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"descricao", trabalhoRealizado.Descricao);
            cmd.Parameters.AddWithValue(@"data_hora", trabalhoRealizado.Data_Hora);
            cmd.Parameters.AddWithValue(@"resumo", trabalhoRealizado.Resumo);
            cmd.Parameters.AddWithValue(@"endereco", trabalhoRealizado.Endereco);
            cmd.Parameters.AddWithValue(@"ordem_apresentacao", trabalhoRealizado.Ordem_Apresentacao);

            var result = await base.ExecuteScalarAsync(cmd);

            if (result != null)
            {
                trabalhoRealizado.Id_Portfolio = long.Parse(result.ToString());
            }

            return trabalhoRealizado.Id_Portfolio > 0;
        }

        public async Task<bool> IncluirAnexoPortfolio(AnexoTrabalhoRealizado anexo)
        {
            string query = "insert into anexo_portfolio_tb (id_portfolio, anexo_base64, extensao_arquivo)" +
                " values (@id_portfolio, @anexo_base64, @extensao_arquivo)";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"id_portfolio", anexo.Id_Portfolio);
            cmd.Parameters.AddWithValue(@"anexo_base64", anexo.Anexo_Base64);
            cmd.Parameters.AddWithValue(@"extensao_arquivo", anexo.Extensao_Arquivo);


            var result = await base.ExecuteCommand(cmd);
            return result;
        }

        public async Task<bool> AtualizarPortfolio(TrabalhoRealizado trabalhoRealizado)
        {
            string query = "update portfolio_tb set descricao = @descricao, data_hora = @data_hora, resumo = @resumo," +
                " endereco = @endereco, ordem_apresentacao = @ordem_apresentacao where id_portfolio = @id_portfolio";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"id_portfolio", trabalhoRealizado.Id_Portfolio);
            cmd.Parameters.AddWithValue(@"descricao", trabalhoRealizado.Descricao);
            cmd.Parameters.AddWithValue(@"data_hora", trabalhoRealizado.Data_Hora);
            cmd.Parameters.AddWithValue(@"resumo", trabalhoRealizado.Resumo);
            cmd.Parameters.AddWithValue(@"endereco", trabalhoRealizado.Endereco);
            cmd.Parameters.AddWithValue(@"ordem_apresentacao", trabalhoRealizado.Ordem_Apresentacao);

            return await base.ExecuteCommand(cmd);
        }

        public Task<bool> ExcluirPortfolio(long Id_Portfolio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrabalhoRealizado> ObterPortfoliosVitrine()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrabalhoRealizado>> ObterTodosPortfolios(TrabalhoRealizado trabalhoRealizado)
        {
            string query = "select * from  portfolio_tb ";

            var result = await QueryAsync<TrabalhoRealizado>(query);

            return result;
        }

        public async Task<bool> ExcluirAnexo(long Id_Portfolio)
        {
            string query = " delete from anexo_portfolio_tb where id_portfolio = " + Id_Portfolio;

            var result = await this.ExecuteAsync(query);

            return result;
        }
        public async Task<bool> ExcluirTrabalho(long Id_Portfolio)
        {
            string query = " delete from portfolio_tb where id_portfolio = " + Id_Portfolio;

            var result = await this.ExecuteAsync(query);

            return result;
        }
        public async Task<TrabalhoRealizado> ObterPorId(long Id_Portfolio)

        {
            string query = $"select * from portfolio_tb where id_portfolio = {Id_Portfolio}";

            var result = await base.QueryAsync<TrabalhoRealizado>(query);

            return result.FirstOrDefault();


        }

        public async Task<IEnumerable<AnexoTrabalhoRealizado>> ObterTodosAnexosByPortfolio(long Id_Portfolio)
        {
            string query = "select * from anexo_portfolio_tb where id_portfolio = " + Id_Portfolio;

            var result = await base.QueryAsync<AnexoTrabalhoRealizado>(query);
            return result;

        }
    }
}
