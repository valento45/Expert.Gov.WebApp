using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Authorization.Dto
{
    public class UsuarioDto
    {
        public int id_cadastroUsuario { get; set; }
        public string nome { get; set; }
        public string normalizedNome { get; set; }
        public string user_name { get; set; }
        public string senha { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string celular { get; set; }
        public string email { get; set; }



        public Usuario ToUsuario()
        {
            return new Usuario()
            {
                Id_CadastroUsuario = id_cadastroUsuario,
                Nome = nome,
                normalizedNome = normalizedNome,
                UserName = user_name,
                Password = senha,
                Endereco = endereco,
                Numero = numero,
                Cidade = cidade,
                Cep = cep,
                Celular = celular,
                Email = email,
            };
        }

    }
}
