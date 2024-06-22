using FluentValidation;
using Product.Application.UseCases.Command.ProductCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductDelete
{
    internal class ProductDeleteCommandValidator : AbstractValidator<ProductDeleteCommand>
    {
        public ProductDeleteCommandValidator() 
        {
            RuleFor(x => x.Data.Id).NotEmpty().WithMessage("Id Wajib Diisi");
        }
    }
}
