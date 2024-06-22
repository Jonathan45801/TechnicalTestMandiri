using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface.Repository;

namespace User.Application.UseCases.Queries.Token
{
    internal class TokenQueriesHandler : IRequestHandler<TokenQueries,TokenDto>
    {
        private readonly IUserLoginRepository _context;
        public TokenQueriesHandler(IUserLoginRepository context) 
        {
            _context = context;
        }
        public async Task<TokenDto> Handle(TokenQueries request,CancellationToken cancellationToken)
        {
            var data = await _context.GetUser(request.Token,cancellationToken);
            return new TokenDto()
            {
                Id= data.Id,
                userName=data.userName,
                Success = true,
                Message="Sukses"
            };
        }
    }
}
