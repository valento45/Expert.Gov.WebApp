using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Repositorys.Interfaces;
using Expert.Gov.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> AtualizarUsuario(Usuario user)
        {
          return await _usuarioRepository.AtualizarUsuario(user);
        }

        public async Task<bool> ExcluirUsuario(long id)
        {
            return await _usuarioRepository.ExcluirUsuario(id);
        }

        public async Task<bool> IncluirUsuario(Usuario user)
        {
            return await _usuarioRepository.IncluirUsuario(user);
        }
    }
}
