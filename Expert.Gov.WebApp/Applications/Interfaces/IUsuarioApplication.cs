using Expert.Gov.Core.Authorization;
using Expert.Gov.WebApp.Models;

namespace Expert.Gov.WebApp.Applications.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<bool> IncluirUsuario(UsuarioViewModel usuarioViewModel);
        Task<bool> AtualizarUsuario(Usuario user);
        Task<bool> ExcluirUsuario(long id);
    }
}
