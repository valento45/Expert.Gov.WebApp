using Expert.Gov.Core.Authorization;
using Expert.Gov.WebApp.Applications.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class AdministrativoController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public AdministrativoController(UserManager<Usuario> userManager, IUsuarioApplication usuarioApplication) : base(userManager)
        {
            _usuarioApplication = usuarioApplication;
        }


        [HttpGet]
        public IActionResult PainelAdministrador()
        {

            if(!User.IsAuthenticated())
                return View("Unauthorized");

            return View("Administrativo/PainelAdministrador");
        }
    }
}
