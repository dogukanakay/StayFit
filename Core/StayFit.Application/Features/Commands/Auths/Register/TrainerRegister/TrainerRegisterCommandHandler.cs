using MediatR;
using StayFit.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Auths.Register.TrainerRegister
{
    public class TrainerRegisterCommandHandler : IRequestHandler<TrainerRegisterCommandRequest, TrainerRegisterCommandResponse>
    {
        private readonly IAuthRepository _authRepository;

        public TrainerRegisterCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<TrainerRegisterCommandResponse> Handle(TrainerRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            string response = await _authRepository.TrainerRegisterAsync(request.TrainerRegisterDto);
            return new() { Message = response, Success = true };
        }
    }

}
