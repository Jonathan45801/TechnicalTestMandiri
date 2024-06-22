using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductCreate
{
    public record ProductCreateCommand(ProductCreateData Data) : IRequest<ProductCreateDto>;
    public class ProductCreateData
    {
        public string? productName { get; set; }
        public string? productDescription { get; set; }
        public int Harga { get; set; }
    }
}
