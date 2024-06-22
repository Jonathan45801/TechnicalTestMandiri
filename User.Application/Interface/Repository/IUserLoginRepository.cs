using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.CustomEntities;
using User.Domain.Entities;

namespace User.Application.Interface.Repository
{
    public interface IUserLoginRepository
    {
        Task<int> InsertAsync(string userName, string passWord, CancellationToken cancellationToken);
        Task<bool> CheckUser(string userName,string passWord,CancellationToken cancellationToken);
        Task<bool> CheckUserDaftar(string userName, CancellationToken cancellationToken);
        Task<UserLogin> CheckUserPassword(string userName, string passWord, CancellationToken cancellationToken);
        Task<UserToken> GetUser(string token,CancellationToken cancellationToken);
        string GenerateToken(CancellationToken cancellationToken);
    }
}
