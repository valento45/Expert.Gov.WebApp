using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.TrabalhosRealizados
{
    public class AnexoTrabalhoRealizado
    {
        public int Id_Anexo { get; set; }
        public long Id_Portfolio { get; set; }
        public string Anexo_Base64 { get; private set; }
        public string Extensao_Arquivo { get; private set; }

 
        public AnexoTrabalhoRealizado()
        {
            
        }

        public AnexoTrabalhoRealizado(DataRow dr)
        {
            
        }

        public AnexoTrabalhoRealizado(long idPortfolio)
        {
            Id_Portfolio = idPortfolio;
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
