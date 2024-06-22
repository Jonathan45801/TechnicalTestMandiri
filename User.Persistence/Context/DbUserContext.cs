using Microsoft.EntityFrameworkCore;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface;
using User.Domain.Entities;
namespace User.Persistence.Context
{
    public class DbUserContext : DbContext, IDbUserContext
    {
        public DbUserContext(DbContextOptions<DbUserContext> options) : base(options)
        {

        }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<UserLoginToken> UserLoginToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbUserContext).Assembly);
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
