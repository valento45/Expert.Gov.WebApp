using Expert.Gov.Core.Request.TrabalhosRequest;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class TrabalhoRealizadoController : Controller
    {

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
        public async Task<IActionResult> SalvarTrabalho(TrabalhoRealizadoRequest trabalhoRealizadoRequest)
        {
            return View();
        }
    }
}
