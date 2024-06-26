﻿using MediatR;

namespace User.Application.UseCases.Command.Register
{
    public record RegisterCommand(RegisterCommandData Data) : IRequest<RegisterDto>;
    public class RegisterCommandData
    {
        public string? userName { get; set; }
        public string? passWord { get; set; }
    }
}
