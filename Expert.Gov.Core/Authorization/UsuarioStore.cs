using Dapper;
using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Repositorys;
using Expert.Gov.Core.Repositorys.Interfaces;
using Expert.Gov.Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;

namespace Expert.Gov.WebApp.Authorization
{
    public class UsuarioStore : IUserStore<Usuario>, IUserPasswordStore<Usuario>, IUserClaimStore<Usuario>
    {
        protected readonly IDbConnection _connection;
        protected readonly IUsuarioRepository _usuarioRepository;

        public UsuarioStore(IDbConnection connection, IUsuarioRepository usuarioRepository)
        {
            _connection = connection;
            _usuarioRepository = usuarioRepository;
        }


        public Task AddClaimsAsync(Usuario user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            var inserted = await _connection.ExecuteAsync("insert into sys.cadastroUsuario_tb (nome, normalizedLogin, senha, " +
                " endereco, numero, cidade, cep, celular, email)" +
                " values (@nome, @normalizedLogin, @senha,  @endereco, @numero, @cidade, @cep, @celular, @email)",
                new
                {
                    nome = user.Nome,
                    normalizedLogin = user.NormalizedUserName,
                    senha = user.PasswordHash,
                    endereco = user.Endereco,
                    numero = user.Numero,
                    cidade = user.Cidade,
                    cep = user.Cep,
                    celular = user.Celular,
                    email = user.Email
                  
                });

            if (inserted > 0)
                return IdentityResult.Success;
            else
                return IdentityResult.Failed(new IdentityError[] { new IdentityError() { Description = "Erro ao inserir o usuário." } });

        }

        public Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Usuario>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(Usuario user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(Usuario user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(Usuario user, string? normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(Usuario user, string? passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Usuario user, string? userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityResult> IUserStore<Usuario>.CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
