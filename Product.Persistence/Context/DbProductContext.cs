using Microsoft.EntityFrameworkCore;
using Product.Application.Interface;
using Product.Domain.Entities;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence.Context
{
    public class DbProductContext : DbContext, IDbProductContext
    {
        public DbProductContext(DbContextOptions<DbProductContext> options) : base(options)
        {

        }
        public DbSet<ProductHeader> Product { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<ApiConfig> ApiConfig { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbProductContext).Assembly);
        }

        public IStoredProcBuilder loadStoredProcedureBuilder(string val)
        {
            return this.LoadStoredProc(val);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
