using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface.Repository;
using User.Domain.Entities;

namespace User.Application.UseCases.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand,LoginDto>
    {
        private readonly IUserLoginRepository _userLogin;
        private readonly IUserLoginTokenRepository _userLoginToken;
        public LoginCommandHandler(IUserLoginRepository userLogin,IUserLoginTokenRepository userLoginToke) 
        {
            _userLogin = userLogin;
            _userLoginToken = userLoginToke;
        }
        public async Task<LoginDto> Handle(LoginCommand request,CancellationToken cancellationToken)
        {
            var response = new LoginDto();
            var checkData = await _userLogin.CheckUserPassword(request.Data.userName!, request.Data.passWord!, cancellationToken);
            if (checkData is null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "User tidak terdaftar";
            }
            else
            {
                var token = new UserLoginToken()
                {
                    UserLoginId = checkData.Id,
                    AuthToken = _userLogin.GenerateToken(cancellationToken),
                    Type = "Bearer",
                    ExpiresAt = DateTime.Now.AddHours(2)
                };
                await _userLoginToken.InsertAsync(token,cancellationToken);
                response.Data = token.Adapt<LoginData>();
                response.Success = true;
                response.Message = "SUkses";
            }
            return response;
        }
    }
}
