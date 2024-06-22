using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Product.Application.Interface.Repository;
using Product.Application.Interface;
using Azure.Core;

namespace Product.Infrastructure.AuthMiddleware
{
    public class AuthMeMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public AuthMeMiddleware(RequestDelegate next)
        {
            _requestDelegate = next;
        }
        public async Task InvokeAsync(HttpContext context,IAuthUser _authUser,IAuth auth )
        {
            var request = context.Request.HttpContext.Request;
            if(request.Path.ToString().StartsWith("/Product", StringComparison.CurrentCultureIgnoreCase))
            {
                string authHeader = ReadHttpHeader("Authorization", context);
                if (string.IsNullOrEmpty(authHeader))
                {
                    throw new UnauthorizedAccessException();
                }
                string token = authHeader.Replace("Bearer", "").Trim();
                var dataUser = await _authUser.GetUserByToken(token);

                if (dataUser is null)
                {
                    throw new UnauthorizedAccessException();
                }
                auth.Id = dataUser.Id;
                auth.userName = dataUser.userName;
                await _requestDelegate.Invoke(context);
                return;
            }
            await _requestDelegate.Invoke(context);
            return;
        }
        private static string ReadHttpHeader(string name, HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(name, out StringValues value))
                return value.SingleOrDefault() ?? "";
            throw new UnauthorizedAccessException();


        }
    }
  
}
