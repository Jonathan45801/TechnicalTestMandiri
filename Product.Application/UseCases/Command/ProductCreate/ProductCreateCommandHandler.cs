using MediatR;
using Product.Application.Interface;
using Product.Application.Interface.Repository;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.UseCases.Command.ProductCreate
{
    internal class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand,ProductCreateDto>
    {
        private readonly IProductHeaderRepository _headerRepository;
        private readonly IProductDetailRepository _detailRepository;
        private readonly IAuth _auth;
        public ProductCreateCommandHandler(IProductDetailRepository detailRepository, IProductHeaderRepository headerRepository,IAuth auth)
        {
            _detailRepository = detailRepository;
            _headerRepository = headerRepository;
            _auth = auth;
        }
        public async Task<ProductCreateDto> Handle(ProductCreateCommand request,CancellationToken cancellationToken)
        {
            var productHeader = ChangeEntities(request);
            await _headerRepository.InsertAsync(productHeader,cancellationToken);
            var productDetail = ChangeEntitiesDetail(productHeader, request);
            await _detailRepository.InsertAsync(productDetail,cancellationToken);
            return new ProductCreateDto()
            {
                Success = true,
                Message ="Sukses"
            };
        }

        public ProductHeader ChangeEntities(ProductCreateCommand request)
        {
            ProductHeader header = new ProductHeader();
            header.Id = 0;
            header.NamaProduct = request.Data.productName;
            header.DescriptionProduct = request.Data.productDescription;
            header.CreatedBy = _auth.userName;
            return header;
        }
        public ProductDetail ChangeEntitiesDetail(ProductHeader productHeader,ProductCreateCommand request)
        {
            var detail = new ProductDetail();
            detail.ProductId = productHeader.Id;
            detail.Harga = request.Data.Harga;
            detail.TerJual = 0;
            detail.CreatedBy = _auth.userName;
            return detail;
        }
    }
}
