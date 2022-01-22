using DziennikElektroniczny.Services;
using DziennikElektroniczny.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json.Linq;

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
        public ActionResult Login(LoginView loginView)
        {
            string jwt =  _authService.AuthenticateCredentials(loginView);
            if (jwt == null) return Unauthorized();
            TokenRes token = new TokenRes();
            token.token = jwt;
          return new JsonResult(token);
        }
    }
}
class TokenRes
{
    public string token { get; set; }
}