using Product.Application.Interface;
using Product.Application.Interface.Repository;
using Product.Domain.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoredProcedureEFCore;
namespace Product.Persistence.Repository
{
    public class ProductAllRepository : IProductAllRepository
    {
        private readonly IDbProductContext _context;
        public ProductAllRepository(IDbProductContext context) 
        {
            _context = context;
        }
        public async Task<IList<ProductAll>> Getdata(CancellationToken cancellationToken)
        {
            IList<ProductAll> lis = new List<ProductAll>();
            await _context.loadStoredProcedureBuilder("sp_ProductAll").ExecAsync(async x => lis = await x.ToListAsync<ProductAll>(cancellationToken));
            return lis;
        }
    }
}
