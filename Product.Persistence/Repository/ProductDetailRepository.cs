using Microsoft.EntityFrameworkCore;
using Product.Application.Interface;
using Product.Application.Interface.Repository;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence.Repository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly IDbProductContext _context;
        public ProductDetailRepository(IDbProductContext context) 
        {
            _context = context;
        }

        public async Task<int> DeleteAsync(int productId, CancellationToken cancellationToken)
        {
             var checkData = await _context.ProductDetail.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            if(checkData is not null)
            {
                _context.ProductDetail.Remove(checkData);
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ProductDetail> Get(int productId, CancellationToken cancellationToken)
        {
            return await _context.ProductDetail.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(ProductDetail product, CancellationToken cancellationToken)
        {
            _context.ProductDetail.Add(product);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(ProductDetail product, CancellationToken cancellationToken)
        {
            var checkData = await _context.ProductDetail.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
            if(checkData is not null)
            {
                checkData.Harga = product.Harga;
                checkData.TerJual += product.TerJual;
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
