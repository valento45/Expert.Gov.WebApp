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

        public long Id_Portfolio { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Hora { get; set; }
        public string Resumo { get; set; }
        public string Endereco { get; set; }
        public int Ordem_Apresentacao { get; set; }


        public ICollection<AnexoTrabalhoRealizado> Imagens { get; set; }


        public TrabalhoRealizado()
        {
            Imagens = new List<AnexoTrabalhoRealizado>();
        }


        public TrabalhoRealizado(DataRow dr)
        {

        }


        public void InformarAnexo(AnexoTrabalhoRealizado anexoTrabalhoRealizado)
        {
            if (Imagens == null)
                Imagens = new List<AnexoTrabalhoRealizado>();

            Imagens.Add(anexoTrabalhoRealizado);
        }


       
    }
}
