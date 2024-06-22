using FluentValidation;
using Product.Application.UseCases.Command.ProductCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductUpdate
{
    internal class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidator()
        {
            RuleFor(x => x.Data.Id).GreaterThan(0).WithMessage("Id Barang Wajib Diisi");
            RuleFor(x => x.Data.productName).NotEmpty().WithMessage("Product Name Wajib Diisi");
            RuleFor(x => x.Data.Harga).GreaterThan(0).WithMessage("Harga Wajib Diisi");
        }
    }
}
