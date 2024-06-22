using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace User.Application.UseCases.Command.Login
{
    internal class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Data.userName).NotEmpty().WithMessage("UserName Wajib Diisi");
            RuleFor(x => x.Data.passWord).NotEmpty().WithMessage("Password Wajib Diisi");
        }
    }
}
