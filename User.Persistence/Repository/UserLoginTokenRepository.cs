using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface;
using User.Application.Interface.Repository;
using User.Domain.Entities;
namespace User.Persistence.Repository
{
    internal class UserLoginTokenRepository : IUserLoginTokenRepository
    {
        private readonly IDbUserContext _context;
        public UserLoginTokenRepository(IDbUserContext context) 
        {
            _context = context;
        }

        public async Task<int> InsertAsync(UserLoginToken userLoginToken, CancellationToken cancellationToken)
        {
            _context.UserLoginToken.Add(userLoginToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateAsync(UserLoginToken userLoginToken, CancellationToken cancellationToken)
        {
            _context.UserLoginToken.Update(userLoginToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
