﻿using DziennikElektroniczny.Models;
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
        private int roleValue;
        public AuthFilter(AuthService authService, int roleValue)
        {
            this._authService = authService;
            this.roleValue = roleValue;

        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var jwtFromHeaders = context.HttpContext.Request.Headers["JWT"];
            Person person = _authService.GetPersonFromJWT(jwtFromHeaders);
            if (person.Role < roleValue || person == null)
            {
                context.HttpContext.Response.StatusCode = 401;
            }
            else
            {
                await next();
            }
        }
    }
}
