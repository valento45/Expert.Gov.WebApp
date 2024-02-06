using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.TrabalhosRealizados
{
    public class ImagemTrabalhoRealizado
    {

        public long IdTrabalho { get; set; }
        public string ImagemBase64 { get; set; }
        public int OrdemApresentacao { get; set; }


        public ImagemTrabalhoRealizado()
        {
            
        }

        public ImagemTrabalhoRealizado(DataRow dr)
        {
            
        }



    }
}
