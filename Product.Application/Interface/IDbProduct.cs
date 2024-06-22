using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Product.Application.Interface
{
    public interface IDbProduct: IDisposable
    {
        DbSet<ProductHeader> Product { get; set; }
        DbSet<ProductDetail>ProductDetail { get; set; }
        IStoredProcBuilder loadStoredProcedureBuilder(string val);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
