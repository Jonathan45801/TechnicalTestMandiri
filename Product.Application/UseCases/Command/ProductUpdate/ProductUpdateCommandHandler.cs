using MediatR;
using Product.Application.Interface.Repository;
using Product.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Application.UseCases.Command.ProductCreate;
using Product.Domain.Entities;

namespace Product.Application.UseCases.Command.ProductUpdate
{
    internal class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand,ProductUpdateDto>
    {
        private readonly IProductHeaderRepository _headerRepository;
        private readonly IProductDetailRepository _detailRepository;
        private readonly IAuth _auth;
        public ProductUpdateCommandHandler(IProductDetailRepository detailRepository, IProductHeaderRepository headerRepository, IAuth auth) 
        {
            _detailRepository = detailRepository;
            _headerRepository = headerRepository;
            _auth = auth;
        }
        public async Task<ProductUpdateDto> Handle(ProductUpdateCommand request,CancellationToken cancellationToken)
        {
            var productHeader = ChangeEntities(request);
            await _headerRepository.UpdateAsync(productHeader, cancellationToken);
            var productDetail = ChangeEntitiesDetail(productHeader, request);
            await _detailRepository.UpdateAsync(productDetail, cancellationToken);
            return new ProductUpdateDto()
            {
                Success = true,
                Message = "Sukses"
            };
        }
        public ProductHeader ChangeEntities(ProductUpdateCommand request)
        {
            ProductHeader header = new ProductHeader();
            header.Id = 0;
            header.NamaProduct = request.Data.productName;
            header.DescriptionProduct = request.Data.productDescription;
            header.CreatedBy = _auth.userName;
            return header;
        }
        public ProductDetail ChangeEntitiesDetail(ProductHeader productHeader, ProductUpdateCommand request)
        {
            var detail = new ProductDetail();
            detail.ProductId = request.Data.Id;
            detail.Harga = request.Data.Harga;
            detail.TerJual = request.Data.Terjual;
            detail.CreatedBy = _auth.userName;
            return detail;
        }
    }
}
