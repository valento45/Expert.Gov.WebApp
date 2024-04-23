using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.SolicitacaoSugestao
{
    public class AnexoSolicitacao
    {
        public int Id_Anexo { get; set; }
        public long Id_Solicitacao { get; set; }
        public string Anexo_Base64 { get; private set; }
        public string Extensao_Arquivo { get; private set; }



        public AnexoSolicitacao()
        {

        }

        public AnexoSolicitacao(DataRow dr)
        {

        }

        public AnexoSolicitacao(long idSolicitacao)
        {
            Id_Solicitacao = idSolicitacao;
        }


        public void InformarAnexoBase64(string anexo)
        {
            Anexo_Base64 = anexo;
        }

        public void InformarExtensao(string extensao)
        {
            Extensao_Arquivo = extensao;
        }
    }
}

