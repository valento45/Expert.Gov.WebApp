using Expert.Gov.Core.Models.TrabalhosRealizados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Gov.Core.Models.SolicitacaoSugestao
{
    public class Solicitacao
    {
        public long Id_Solicitacao { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco_solicitacao { get; set; }
        public string Numero_solicitacao { get; set; }
        public string Cep_solicitacao { get; set; }
        public string Descricao_Titulo { get; set; }
        public string Descricao_Sugestao_Melhoria { get; set; }

        public ICollection<AnexoSolicitacao> Imagens { get; set; }

        public Solicitacao()
        {
            Imagens = new List<AnexoSolicitacao>();
        }

        public string ObterEnderecoFormatado()
        {
            var sb = new StringBuilder();

            sb.Append(Endereco_solicitacao);

            if (!string.IsNullOrEmpty(Numero_solicitacao))
                sb.Append($", {Numero_solicitacao}");

            if (!string.IsNullOrEmpty(Cep_solicitacao))
                sb.Append($" - {Cep_solicitacao}");

            return sb.ToString();
        }



    }
}
