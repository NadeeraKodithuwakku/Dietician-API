using Dietician.Application;
using Dietician.Model;
using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dietician.Web
{
    [ApiController]
    [Route("Auths")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public Task<IActionResult> SignInAsync(SignInModel model)
        {
            return _authService.SignInAsync(model).ResultAsync();
        }
    }
}
