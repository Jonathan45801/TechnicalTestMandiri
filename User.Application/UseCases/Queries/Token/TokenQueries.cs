using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.UseCases.Queries.Token
{
    public record TokenQueries(string Token) : IRequest<TokenDto>;
    
}
