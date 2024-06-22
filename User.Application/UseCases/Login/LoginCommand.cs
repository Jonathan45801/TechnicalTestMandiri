using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.UseCases.Login
{
    public record LoginCommand(LoginCommandData Data) : IRequest<LoginDto>;
    public class LoginCommandData
    {
        public string? userName { get; set; }
        public string? passWord { get; set; }
    }
}
