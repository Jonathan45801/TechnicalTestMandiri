using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface.Repository
{
    public interface IAuthUser
    {
        Task<User> GetUserByToken(string token);
    }
}
