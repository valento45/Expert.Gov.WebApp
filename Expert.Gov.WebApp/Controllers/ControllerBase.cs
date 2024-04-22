using Expert.Gov.Core.Authorization;
using Expert.Gov.Core.Models.Authentication;
using Expert.Gov.Core.Secutiry;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Expert.Gov.WebApp.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly UserManager<Usuario> _userManager;

        public ControllerBase(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<bool> Autenticar(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            user.PasswordHash = Security.Encrypt(model.Password);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var identity = new ClaimsIdentity("cookies");

                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Hash, user.PasswordHash));
                    identity.AddClaims(await _userManager.GetClaimsAsync(user));

                    var userClaim = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("cookies", userClaim);

                    return true;
                }
            }

            return false;
        }

    }
}
