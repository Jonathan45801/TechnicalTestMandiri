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
        private readonly IDbProduct _context;
        public ProductDetailRepository(IDbProduct context) 
        {
            _context = context;
        }
        public async Task<ProductDetail> Get(int productId, CancellationToken cancellationToken)
        {
            return await _context.ProductDetail.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        }
    }
}
