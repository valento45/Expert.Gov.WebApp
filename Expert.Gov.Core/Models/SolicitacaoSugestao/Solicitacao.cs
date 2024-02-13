using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.SolicitacaoSugestao
{
    public class Solicitacao
    {
        public int IdSolicitacao { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }

        public string DescricaoProblema { get; set; }
        public string DescricaoSugestaoMelhoria { get; set; }
        public ICollection<AnexoSolicitacao> Anexos { get; set; }



        public string ObterEnderecoFormatado()
        {
            return $"{Endereco}, {Numero} - {CEP}";
        }
    }
}
