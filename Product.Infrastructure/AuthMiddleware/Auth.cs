using Product.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.AuthMiddleware
{
    public class Auth : IAuth
    {
        public int Id { get; set; }
        public string? userName { get; set; }
    }
}
