using Microsoft.EntityFrameworkCore;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;
using User.Domain.Entities;
namespace User.Application.Interface
{
    public interface IDbUserContext : IDisposable
    {
        DbSet<UserLogin> UserLogin { get; set; }
        DbSet<UserLoginToken> UserLoginToken { get; set; }
        IStoredProcBuilder loadStoredProcedureBuilder(string val);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
