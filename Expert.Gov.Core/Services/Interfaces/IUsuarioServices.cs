using Expert.Gov.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Services.Interfaces
{
    public interface IUsuarioServices
    {
        Task<bool> IncluirUsuario(Usuario user);
        Task<bool> AtualizarUsuario(Usuario user);
        Task<bool> ExcluirUsuario(long id);
    }
}
