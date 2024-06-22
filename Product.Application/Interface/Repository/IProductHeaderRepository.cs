using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface.Repository
{
    public interface IProductHeaderRepository
    {
        Task<int> InsertAsync(ProductHeader Product, CancellationToken cancellationToken);
        Task<int> UpdateAsync(ProductHeader Product, CancellationToken cancellationToken);
        Task<int> DeleteAsync(int Id,CancellationToken cancellationToken);
    }
}
