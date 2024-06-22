using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductCreate
{
    internal class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateCommandValidator() 
        {
            RuleFor(x => x.Data.productName).NotEmpty().WithMessage("Product Name Wajib Diisi");
            RuleFor(x => x.Data.Harga).GreaterThan(0).WithMessage("Harga Wajib Diisi");
        }
    }
}
