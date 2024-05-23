using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.TrabalhosRealizados
{
    public class TrabalhosRealizadosLista 
    {

        public IEnumerable<TrabalhoRealizado> ListaTrabalhosRealizados { get; set; }

        public TrabalhosRealizadosLista()
        {
            ListaTrabalhosRealizados = new List<TrabalhoRealizado>();
        }

    }
}
