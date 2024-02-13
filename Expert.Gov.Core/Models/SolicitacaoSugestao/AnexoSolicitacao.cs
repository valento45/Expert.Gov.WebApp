using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.SolicitacaoSugestao
{
    public class AnexoSolicitacao
    {
        public int IdSolicitacao { get; set; }
        public string AnexoBase64 { get; set; }
        public string TipoAnexo { get; set; }
    }
}
