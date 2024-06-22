using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace User.Application.UseCases.Register
{
    internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() 
        {
            RuleFor(x => x.Data.userName).NotEmpty().WithMessage("UserName Wajib Diisi");
            RuleFor(x => x.Data.passWord).NotEmpty().WithMessage("Password Wajib Diisi");
        }
    }
}
