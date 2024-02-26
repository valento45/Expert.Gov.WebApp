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
            cmd.Parameters.AddWithValue(@"data_hora", trabalhoRealizado.DataHora);
            cmd.Parameters.AddWithValue(@"resumo", trabalhoRealizado.Resumo);
            cmd.Parameters.AddWithValue(@"endereco", trabalhoRealizado.Local);
            cmd.Parameters.AddWithValue(@"ordem_apresentacao", trabalhoRealizado.OrdemApresentacao);

            var result= await base.ExecuteScalarAsync(cmd);

            if(result != null)
            {
                trabalhoRealizado.IdTrabalho = long.Parse(result.ToString());
            }

            return trabalhoRealizado.IdTrabalho > 0;
        }


        public async Task<bool> IncluirAnexoPortfolio(AnexoTrabalhoRealizado anexo)
        {
            string query = "insert into anexo_portfolio_tb (id_portfolio, anexo_base64, extensao_arquivo)" +
                " values (@id_portfolio, @anexo_base64, @extensao_arquivo)";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"id_portfolio", anexo.IdPortfolio);
            cmd.Parameters.AddWithValue(@"anexo_base64", anexo.AnexoBase64);
            cmd.Parameters.AddWithValue(@"extensao_arquivo", anexo.ExtensaoArquivo);


            var result = await base.ExecuteCommand(cmd);
            return result;
        }



        public async Task<bool> AtualizarPortfolio(TrabalhoRealizado trabalhoRealizado)
        {
            string query = "update portfolio_tb set descricao = @descricao, data_hora = @data_hora, resumo = @resumo," +
                " endereco = @endereco, ordem_apresentacao = @ordem_apresentacao where id_portfolio = @id_portfolio";

            NpgsqlCommand cmd = new NpgsqlCommand(query);
            cmd.Parameters.AddWithValue(@"id_portfolio", trabalhoRealizado.IdTrabalho);
            cmd.Parameters.AddWithValue(@"descricao", trabalhoRealizado.Descricao);
            cmd.Parameters.AddWithValue(@"data_hora", trabalhoRealizado.DataHora);
            cmd.Parameters.AddWithValue(@"resumo", trabalhoRealizado.Resumo);
            cmd.Parameters.AddWithValue(@"endereco", trabalhoRealizado.Local);
            cmd.Parameters.AddWithValue(@"ordem_apresentacao", trabalhoRealizado.OrdemApresentacao);

            return await base.ExecuteCommand(cmd);
        }

        public Task<bool> ExcluirPortfolio(long idPortfolio)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<TrabalhoRealizado> ObterPortfoliosVitrine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrabalhoRealizado> ObterTodosPortfolios()
        {
            throw new NotImplementedException();
        }


    }
}
