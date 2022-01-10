using DziennikElektroniczny.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.Utils
{
    public class AuthFilter : Attribute, IAsyncResourceFilter
    {
        private AuthService _authService;
        public AuthFilter(AuthService authService, string role)
        {
            this._authService = authService;

        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var cred = context.HttpContext.Request.Headers;
            String auth = cred["Auth"];


            //_authService.AuthenticateCredentials();
             await next();
        }
    }
}
