using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class ContatoController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> SolicitarMelhorias()
        {
            return View();
        }
    }
}
