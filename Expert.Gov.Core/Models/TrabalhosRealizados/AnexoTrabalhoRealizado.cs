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
        public int IdAnexo { get; set; }
        public long IdPortfolio { get; set; }
        public string AnexoBase64 { get; private set; }
        public string ExtensaoArquivo { get; private set; }
  

        public AnexoTrabalhoRealizado()
        {
            
        }

        public AnexoTrabalhoRealizado(DataRow dr)
        {
            
        }

        public AnexoTrabalhoRealizado(long idPortfolio)
        {
            IdPortfolio = idPortfolio;
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
