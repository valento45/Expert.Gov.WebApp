using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.TrabalhosRealizados
{
    public class TrabalhoRealizado
    {
        public long IdTrabalho { get; set; }
        public string  Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public string Resumo { get; set; }
        public string Local { get; set; }
        public int OrdemApresentacao { get; set; }


        public IEnumerable<AnexoTrabalhoRealizado> Imagens { get; set; }


        public TrabalhoRealizado()
        {
            Imagens = new List<AnexoTrabalhoRealizado>();  
        }


        public TrabalhoRealizado(DataRow dr)
        {
            
        }
    }
}
