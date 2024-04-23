using Expert.Gov.Core.Models.CadrastoUsuario;
using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Authorization
{
    public class Usuario : IdentityUser<long>
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

        public ICollection<AnexoFotoPessoa> Imagens { get; set; }

        public Usuario()
        {
            Imagens = new List<AnexoFotoPessoa>();
        }

        public string ObterEnderecoFormatado()
        {
            return $"{Endereco}, {Numero}, {Cidade} - {Cep} ";
        }


        public bool CheckPassword(string passwordHash)
        {
            return Password.Equals(passwordHash);
        }

    }
}
