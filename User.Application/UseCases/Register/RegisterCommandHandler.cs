using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface.Repository;
using User.Domain.Entities;

namespace User.Application.UseCases.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand,RegisterDto>
    {
        private readonly IUserLoginRepository _userLogin;
        public RegisterCommandHandler(IUserLoginRepository userLogin) 
        {
            _userLogin = userLogin;
        }
        public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkData = await _userLogin.CheckUserDaftar(request.Data.userName!, cancellationToken);
                if(checkData)
                {
                    return new RegisterDto()
                    {
                        Success = true,
                        Message = "User Sudah Data"
                    };
                }
                else
                {
                    await _userLogin.InsertAsync(request.Data.userName!, request.Data.passWord, cancellationToken);
                }
                return new RegisterDto()
                {
                    Success = true,
                    Message = "Sukses"
                };
            }
            catch (Exception ex) 
            {
                return new RegisterDto()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

    }
}
