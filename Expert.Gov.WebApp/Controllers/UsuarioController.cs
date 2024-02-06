using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class UsuarioController : Controller
    {


        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
