using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Secutiry;
using Expert.Gov.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class UsuarioController : ControllerBase
    {

        public UsuarioController(UserManager<Usuario> userManager) : base(userManager)
        {

        }


        [HttpGet]
        public async Task<IActionResult> CadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarUsuario(UsuarioViewModel usuarioViewModel)
        {

            Usuario usuario = new Usuario
            {
                Nome = usuarioViewModel.Nome,
                Celular = usuarioViewModel.Celular,
                Cep = usuarioViewModel.Cep,
                Cidade = usuarioViewModel.Cidade,
                Email = usuarioViewModel.Email,
                Endereco = usuarioViewModel.Endereco,
                Numero = usuarioViewModel.Numero,
                Password = usuarioViewModel.Password,
                PasswordHash = Security.Encrypt(usuarioViewModel.Password),
                UserName = usuarioViewModel.Usuario,
                PhoneNumber = usuarioViewModel.Celular

            };

            var result = await _userManager.CreateAsync(usuario);

            if (result.Succeeded)
            {
                MessageViewModel message = new MessageViewModel("Usuário incluído com sucesso!", "Gerencia no painel de administrador.");
                return View("SucessoMessage", message);
            }
            else
                throw new Exception("Erro ao cadastrar usuário");
            
        }


    }
}
