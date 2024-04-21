using System.ComponentModel.DataAnnotations;

namespace Expert.Gov.WebApp.Models
{
    public class UsuarioViewModel
    {
        public long Id_CadastroUsuario { get; set; }
        public string Nome { get; set; }
        public string normalizedNome { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public List<IFormFile> Anexos { get; set; }

        public UsuarioViewModel()
        {
            Anexos = new List<IFormFile>();
        }

        public string ObterEnderecoFormatado()
        {
            return $"{Endereco}, {Numero}, {Cidade} - {Cep}";
        }

    }
}
