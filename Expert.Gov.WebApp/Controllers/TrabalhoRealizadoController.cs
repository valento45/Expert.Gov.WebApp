using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Models.TrabalhosRealizados;
using Expert.Gov.Core.Request.TrabalhosRequest;
using Expert.Gov.WebApp.Applications.Interfaces;
using Expert.Gov.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication.PgOutput.Messages;
using System.Diagnostics;

namespace Expert.Gov.WebApp.Controllers
{
    public class TrabalhoRealizadoController : ControllerBase
    {
        private readonly IPortfolioApplication _portfolioApplication;

        public TrabalhoRealizadoController(IPortfolioApplication portfolioApplication, UserManager<Usuario> userManager) : base(userManager)
        {
            _portfolioApplication = portfolioApplication;
        }

        [HttpGet]
        public async Task<IActionResult> TrabalhosRealizados()
        {


            var trabalhoRealizadoLista_ = new TrabalhosRealizadosLista();

            trabalhoRealizadoLista_.ListaTrabalhosRealizados = await _portfolioApplication.ObterTodosPortfolios(new TrabalhoRealizado());


            return View(trabalhoRealizadoLista_);
        }

        [HttpGet]
        public async Task<IActionResult> TrabalhosRealizadosAdmin()
        {
            if (!User.IsAuthenticated())
                return View("Unauthorized");

            var trabalhoRealizadoLista_ = new TrabalhosRealizadosLista();

            trabalhoRealizadoLista_.ListaTrabalhosRealizados = await _portfolioApplication.ObterTodosPortfolios(new TrabalhoRealizado());


            return View(trabalhoRealizadoLista_);
        }



        [HttpGet]
        public async Task<IActionResult> IncluirTrabalho()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarTrabalho(PortfolioViewModel portfolioViewModel)
        {

            if (portfolioViewModel.Id_Portfolio > 0)
            {


                await _portfolioApplication.AtualizarPortfolio(portfolioViewModel);
            }
            else
            {
                await _portfolioApplication.IncluirPortfolio(portfolioViewModel);
            }

            MessageViewModel message = new MessageViewModel("Trabalho incluído com sucesso!", "Gerencia no painel de administrador os trabalhos realizados.");
            return View("SucessoMessage", message);

        }

        public async Task<IActionResult> ExcluirAnexo(long Id_Portfolio)
        {
            var result = await _portfolioApplication.ExcluirAnexo(Id_Portfolio);

            return RedirectToAction(nameof(TrabalhosRealizados));
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirTrabalho(long id)
        {

            var result = await _portfolioApplication.ExcluirTrabalho(id);

            return RedirectToAction(nameof(TrabalhosRealizados));

        }

        [HttpGet]
        public async Task<IActionResult> EditarTrabalho(long id)
        {
            var result = await _portfolioApplication.ObterPorId(id);

            var portfolioViewModel = new PortfolioViewModel();

            portfolioViewModel.Id_Portfolio = result.Id_Portfolio;
            portfolioViewModel.Descricao = result.Descricao;
            portfolioViewModel.DataHora = result.Data_Hora;
            portfolioViewModel.Resumo = result.Resumo;
            portfolioViewModel.Local = result.Endereco;


            return View(nameof(IncluirTrabalho), portfolioViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> VerTrabalho([FromBody] TrabalhoRealizado trabalhoRealizado)
        {


            return View(trabalhoRealizado);
        }

    }
}
