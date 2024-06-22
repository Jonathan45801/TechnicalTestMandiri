using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Application.Interface.Repository
{
    public interface IUserLoginTokenRepository
    {
        Task<int> UpdateAsync(UserLoginToken userLoginToken, CancellationToken  cancellationToken);
        Task<int> InsertAsync(UserLoginToken userLoginToken, CancellationToken cancellationToken);
    }
}
