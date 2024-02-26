namespace Expert.Gov.WebApp.Models
{
    public class PortfolioViewModel
    {
        public int IdTrabalho { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public string Resumo { get; set; }
        public string Local { get; set; }

        public List<IFormFile> Anexos { get; set; }



        public PortfolioViewModel()
        {
            Anexos = new List<IFormFile>();
        }
    }
}
