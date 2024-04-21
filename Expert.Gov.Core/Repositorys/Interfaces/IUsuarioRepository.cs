using Expert.Gov.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Repositorys.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> IncluirUsuario(Usuario user);
        Task<bool> AtualizarUsuario(Usuario user);
        Task<bool> ExcluirUsuario(long id);
        Task<Usuario?> ObterPorNome();
        Task<Usuario> GetById();
        Task<string> GetMessage();

        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> GetAllAdministradores();
    }
}
