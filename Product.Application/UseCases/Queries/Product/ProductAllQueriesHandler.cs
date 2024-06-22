using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Application.Interface.Repository;
using Mapster;
namespace Product.Application.UseCases.Queries.Product
{
    internal class ProductAllQueriesHandler : IRequestHandler<ProductAllQueries,ProductAllDto>
    {
        private readonly IProductAllRepository _productAllRepository;
        public ProductAllQueriesHandler(IProductAllRepository productAllRepository)
        {
            _productAllRepository = productAllRepository;
        }
        public async Task<ProductAllDto> Handle(ProductAllQueries request,CancellationToken cancellationToken)
        {
            var getData = await _productAllRepository.Getdata(cancellationToken);

            return new ProductAllDto()
            {
                Data = getData.Adapt<ProductAllData>(),
                Success = true,
                Message = "Data Berhasil"
            };
        }
    }
}
