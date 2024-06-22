using MediatR;
using Product.Application.Interface.Repository;
using Product.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductDelete
{
    internal class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand,ProductDeleteDto>
    {
        private readonly IProductHeaderRepository _headerRepository;
        private readonly IProductDetailRepository _detailRepository;
        private readonly IAuth _auth;
        public ProductDeleteCommandHandler(IProductDetailRepository detailRepository, IProductHeaderRepository headerRepository, IAuth auth)
        {
            _detailRepository = detailRepository;
            _headerRepository = headerRepository;
            _auth = auth;
        }
        public async Task<ProductDeleteDto> Handle(ProductDeleteCommand request,CancellationToken cancellationToken)
        {
            await _detailRepository.DeleteAsync(request.Data.Id, cancellationToken);
            await _headerRepository.DeleteAsync(request.Data.Id, cancellationToken);
            
            return new ProductDeleteDto()
            {
                Success=true,
                Message = "Sukses"
            };
        }
    }
}
