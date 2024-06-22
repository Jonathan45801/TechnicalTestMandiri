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
    public class ProductHeaderRepository : IProductHeaderRepository
    {
        private readonly IDbProductContext _context;
        public ProductHeaderRepository(IDbProductContext context) 
        {
            _context = context;
        }

        public async Task<int> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var getData = await _context.Product.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(getData is not null)
            {
                _context.Product.Remove(getData);
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> InsertAsync(ProductHeader Product, CancellationToken cancellationToken)
        {
            _context.Product.Add(Product);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(ProductHeader Product, CancellationToken cancellationToken)
        {
            _context.Product.Update(Product);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
