using Microsoft.EntityFrameworkCore;
using Product.Application.Interface;
using Product.Application.Interface.Repository;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence.Repository
{
    public class AuthUser : IAuthUser
    {
        private readonly HttpClient _httpClient;
        private readonly IDbProductContext _context;
        public AuthUser(HttpClient httpClient,IDbProductContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<User> GetUserByToken(string token)
        {
            string urlLink = await _context.ApiConfig.Where(x=>x.Name == "User").Select(x=>x.Url).FirstOrDefaultAsync();
            return await _httpClient.GetFromJsonAsync<User>(urlLink+"/Auth/token/"+token);
        }
    }
}
