using DziennikElektroniczny.Services;
using DziennikElektroniczny.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AuthService _authService;
        public LoginController(AuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        public bool Login(LoginView loginView)
        {
            return _authService.AuthenticateCredentials(loginView);
        }
    }
}
