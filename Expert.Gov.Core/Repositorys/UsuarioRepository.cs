using Dapper;
using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Authorization.Dto;
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

    public class UsuarioRepository : RepositoryBase, IUsuarioRepository

    {
        public UsuarioRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<bool> IncluirUsuario(Usuario user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("insert into cadastro_usuario_tb (nome, normalizedLogin, senha, " +
                "endereco, numero, cidade, cep, celular, email) returning id_cadastrousuario;");

            cmd.Parameters.AddWithValue(@"nome", user.Nome);
            cmd.Parameters.AddWithValue(@"normalizedLogin", user.normalizedNome);
            cmd.Parameters.AddWithValue(@"senha", user.Password);
            cmd.Parameters.AddWithValue(@"endereco", user.Endereco);
            cmd.Parameters.AddWithValue(@"numero", user.Numero);
            cmd.Parameters.AddWithValue(@"cidade", user.Cidade);
            cmd.Parameters.AddWithValue(@"cep", user.Cep);
            cmd.Parameters.AddWithValue(@"celular", user.Celular);
            cmd.Parameters.AddWithValue(@"email", user.Email);

            var result = await base.ExecuteScalarAsync(cmd);

            int id;
            if (int.TryParse(result?.ToString(), out id))
            {
                user.Id_CadastroUsuario = id;
                return true;
            }
            else
                return false;
        }

        public async Task<bool> AtualizarUsuario(Usuario user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("update cadastro_usuario_tb set nome = @nome, normalizedLogin = @normalizedLogin" +
                " senha = @senha, endereco = @endereco, numero = @numero, cidade = @cidade, cep = @cep, celular = @celular" +
                " , email = @email where id_usuario = @id_cadastrousuario");

            cmd.Parameters.AddWithValue(@"nome", user.Nome);
            cmd.Parameters.AddWithValue(@"normalizedLogin", user.normalizedNome);
            cmd.Parameters.AddWithValue(@"senha", user.Password);
            cmd.Parameters.AddWithValue(@"endereco", user.Endereco);
            cmd.Parameters.AddWithValue(@"numero", user.Numero);
            cmd.Parameters.AddWithValue(@"cidade", user.Cidade);
            cmd.Parameters.AddWithValue(@"cep", user.Cep);
            cmd.Parameters.AddWithValue(@"celular", user.Celular);
            cmd.Parameters.AddWithValue(@"email", user.Email);
            cmd.Parameters.AddWithValue(@"id_cadastrousuario", user.Id_CadastroUsuario);


            var result = await base.ExecuteCommand(cmd);

            return result;
        }

        public async Task<bool> ExcluirUsuario(long id)
        {
            string query = $"delete from cadastro_usuario_tb where id_cadastrousuario = {id}";

            if (await base.ExecuteAsync(query))
                return await base.ExecuteAsync($"delete from cadastro_usuario_tb where id_cadastrousuario = {id}");

            return false;
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllAdministradores()
        {
            throw new NotImplementedException();
        }      


        async Task<string> IUsuarioRepository.GetMessage()
        {
            return Message;
        }

        public async Task<Usuario?> ObterPorNome(string userNameNormalized)
        {
            string query = $"select * from cadastro_usuario_tb where UPPER(nome) LIKE '{userNameNormalized.ToUpper()}'";
            var usuarioDto = await base._dbConnection.QueryAsync<UsuarioDto>(query);

            return usuarioDto.FirstOrDefault()?.ToUsuario() ?? null;
        }

        public async Task<Usuario> GetById(long idUsuario)
        {
            string query = $"select * from cadastro_usuario_tb where id_cadastroUsuario = {idUsuario}";
            var usuarioDto = await base._dbConnection.QueryAsync<UsuarioDto>(query);

            return usuarioDto.FirstOrDefault()?.ToUsuario() ?? null;
        }
    }
}
