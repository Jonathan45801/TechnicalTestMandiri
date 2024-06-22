using Microsoft.EntityFrameworkCore;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface;
using User.Application.Interface.Repository;
using User.Domain.CustomEntities;
using User.Domain.Entities;
using User.Persistence.Misc;
namespace User.Persistence.Repository
{
    internal class UserLoginRepository : IUserLoginRepository
    {
        private readonly IDbUserContext _context;
        public UserLoginRepository(IDbUserContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckUser(string userName, string passWord, CancellationToken cancellationToken)
        {
            return await _context.UserLogin.Where(x => x.UserName.Equals(userName) && x.Password.Equals(DbUtils.PasswordHash(passWord))).AnyAsync();
        }

        public async Task<bool> CheckUserDaftar(string userName, CancellationToken cancellationToken)
        {
            return await _context.UserLogin.Where(x => x.UserName.Equals(userName)).AnyAsync();
        }

        public async Task<UserLogin> CheckUserPassword(string userName, string passWord, CancellationToken cancellationToken)
        {
            return await _context.UserLogin.Where(x => x.UserName.Equals(userName) && x.Password.Equals(DbUtils.PasswordHash(passWord))).FirstOrDefaultAsync();
        }

        public string GenerateToken(CancellationToken cancellationToken)
        {
            return DbUtils.GenerateAuthToken();
        }

        public async Task<UserToken> GetUser(string token, CancellationToken cancellationToken)
        {
            UserToken result = new UserToken();
            await _context.loadStoredProcedureBuilder("GetUsername")
                .AddParam("token", token)
                .ExecAsync(async x => result = await x.FirstOrDefaultAsync<UserToken>(cancellationToken));
            return result;
        }

        public async Task<int> InsertAsync(string userName, string passWord, CancellationToken cancellationToken)
        {
            var data = new UserLogin()
            {
                Id = 0,
                UserName = userName,
                Password = DbUtils.PasswordHash(passWord),
                CreatedTime = DateTime.Now,
                CreatedBy = userName
            };
            _context.UserLogin.Add(data);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
