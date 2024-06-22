using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Mapster;
using User.Application.Misc;
using User.Application.Model.Query;
using User.Domain.Entities;

namespace User.Application.UseCases.Login
{
    public record LoginDto : BaseDto
    {
        public LoginData? Data { get; set; }
    }
    public class LoginData : MapsterBase<UserLoginToken, LoginData>
    {
        public string? Token { get; set; }
        public string? Type { get; set; }
        public long ExpireAt { get; set; }
        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.Token, src => src.AuthToken)
                .Map(dest => dest.Type, src => src.Type)
                .Map(dest => dest.ExpireAt, src => Utils.DateToTimestamps(src.ExpiresAt));
        }
    }
}
