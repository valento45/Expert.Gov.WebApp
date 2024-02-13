using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> CadastroUsuario()
        {
            return View();
        }
    }
}
