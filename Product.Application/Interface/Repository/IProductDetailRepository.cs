using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface.Repository
{
    public interface IProductDetailRepository
    {
        Task<ProductDetail> Get(int productId,CancellationToken cancellationToken);
    }
}
