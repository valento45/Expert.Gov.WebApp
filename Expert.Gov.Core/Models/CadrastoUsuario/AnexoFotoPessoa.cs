using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.CadrastoUsuario
{
    public class AnexoFotoPessoa
    {
        public int IdAnexo { get; set; }
        public long IdCadastroUsuario { get; set; }
        public string AnexoBase64 { get; private set; }
        public string ExtensaoArquivo { get; private set; }



        public AnexoFotoPessoa()
        {

        }

        public AnexoFotoPessoa(DataRow dr)
        {

        }

        public AnexoFotoPessoa(long idCadastroUsuario)
        {
            IdCadastroUsuario = idCadastroUsuario;
        }


        public void InformarAnexoBase64(string anexo)
        {
            AnexoBase64 = anexo;
        }

        public void InformarExtensao(string extensao)
        {
            ExtensaoArquivo = extensao;
        }

    }
}
