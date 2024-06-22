using Product.Application.Interface;
using Product.Application.Interface.Repository;
using Product.Domain.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence.Repository
{
    public class ProductAllRepository : IProductRepository
    {
        private readonly IDbProduct _context;
        public ProductAllRepository(IDbProduct context) 
        {

        }
        public Task<ProductAll> Getdata(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
