using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductUpdate
{
    public record ProductUpdateCommand(ProductUpdateData Data) : IRequest<ProductUpdateDto>;
    public class ProductUpdateData
    {
        public int Id { get; set; }
        public string? productName { get; set; }
        public string? productDescription { get; set; }
        public int Harga { get; set; }
        public int Terjual { get; set; }
    }
}
