using Expert.Gov.Core.Models.SolicitacaoSugestao;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace Expert.Gov.WebApp.Models
{
    public class SolicitacaoViewModel
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

        public List<IFormFile> Anexos { get; set; }

        public SolicitacaoViewModel()
        {
            Anexos = new List<IFormFile>();
        }

        public string ObterEnderecoFormatado()
        {
            return $"{Endereco_solicitacao}, {Numero_solicitacao} - {Cep_solicitacao}";
        }
    }
}
