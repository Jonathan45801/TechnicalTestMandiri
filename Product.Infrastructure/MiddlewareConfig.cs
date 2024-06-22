using Microsoft.AspNetCore.Builder;
using Product.Infrastructure.AuthMiddleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public static class MiddlewareConfig
    {
        public static IApplicationBuilder UseAuthme(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMeMiddleware>();
        }
    }
}
