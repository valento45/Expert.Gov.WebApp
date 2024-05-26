using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Models.Authentication;
using Expert.Gov.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Expert.Gov.WebApp.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<Usuario> userManager) : base(userManager)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(Exception exception)
        {
            var result = new ErrorViewModel
            {
                Message = exception.Message,
                StackTrace = exception?.StackTrace ?? string.Empty,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };


            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User != null)            
                await base.Deslogar();
            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logar(LoginModel login)
        {
            var result = await base.Autenticar(login);
            if (result != null)
            {
                return View("Administrativo/PainelAdministrador", result);
            }

            return View(login);
        }
    }
}