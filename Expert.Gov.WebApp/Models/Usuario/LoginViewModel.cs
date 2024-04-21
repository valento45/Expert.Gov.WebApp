using System.ComponentModel.DataAnnotations;

namespace Expert.Gov.WebApp.Models.Usuario
{
    public class LoginViewModel
    {
        public string Nome { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
