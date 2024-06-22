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
    public class ProductHeaderRepository : IProductHeaderRepository
    {
        private readonly IDbProduct _context;
        public ProductHeaderRepository(IDbProduct context) 
        {
            _context = context;
        }
        public async Task<int> InsertAsync(ProductHeader Product, CancellationToken cancellationToken)
        {
            _context.Product.Add(Product);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
