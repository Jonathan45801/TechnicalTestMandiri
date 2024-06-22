using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductDelete
{
    public record ProductDeleteCommand(ProductDeleteData Data) : IRequest<ProductDeleteDto>;
    public class ProductDeleteData
    {
       public int Id { get; set; }
    }
}
