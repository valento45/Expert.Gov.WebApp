using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Request.TrabalhosRequest
{
    public class TrabalhoRealizadoRequest
    {

        public long IdTrabalho { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public string Resumo { get; set; }
        public string Local { get; set; }


        public IEnumerable<IFormFile> Anexos { get; set; }


        public TrabalhoRealizadoRequest()
        {
            Anexos = new List<IFormFile>();
        }

    }
}
