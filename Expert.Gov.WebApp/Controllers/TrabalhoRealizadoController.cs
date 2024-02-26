using Expert.Gov.Core.Request.TrabalhosRequest;
using Expert.Gov.WebApp.Applications.Interfaces;
using Expert.Gov.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class TrabalhoRealizadoController : Controller
    {
        private readonly IPortfolioApplication _portfolioApplication;

        public TrabalhoRealizadoController(IPortfolioApplication portfolioApplication)
        {
            _portfolioApplication = portfolioApplication;
        }

        [HttpGet]
        public async Task<IActionResult> TrabalhosRealizados()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> IncluirTrabalho()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarTrabalho(PortfolioViewModel portfolioViewModel)
        {
            var result = await _portfolioApplication.IncluirPortfolio(portfolioViewModel);

            return Ok(result);
        }
    }
}
