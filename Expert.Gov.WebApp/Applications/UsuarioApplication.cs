using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Services.Interfaces;
using Expert.Gov.WebApp.Applications.Interfaces;
using Expert.Gov.WebApp.Models;

namespace Expert.Gov.WebApp.Applications
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioApplication(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        public async Task<bool> IncluirUsuario(UsuarioViewModel usuarioViewModel)
        {
            var obj = new Usuario()
            {
                Id_CadastroUsuario = usuarioViewModel.Id_CadastroUsuario,
                Nome = usuarioViewModel.Nome,
                normalizedNome = usuarioViewModel.normalizedNome,
                Password = usuarioViewModel.Password,
                Endereco = usuarioViewModel.Endereco,
                Numero = usuarioViewModel.Numero,
                Cidade = usuarioViewModel.Cidade,
                Cep = usuarioViewModel.Cep,
                Celular = usuarioViewModel.Celular,
                Email = usuarioViewModel.Email

            };
            return true;
        }

        public async Task<bool> AtualizarUsuario(Usuario user)
        {
            return await _usuarioServices.AtualizarUsuario(user);
        }

        public async Task<bool> ExcluirUsuario(long id)
        {
            return await _usuarioServices.ExcluirUsuario(id);
        }

      
    }
}
