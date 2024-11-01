using AutoMapper;
using MediatR;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Members.UpdateMember
{
    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommandRequest, UpdateMemberCommandResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public UpdateMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<UpdateMemberCommandResponse> Handle(UpdateMemberCommandRequest request, CancellationToken cancellationToken)
        {
            Member member = await _memberRepository.GetMemberProfileAsync(Guid.Parse(request.UpdateMemberDto.Id));
             _mapper.Map(request.UpdateMemberDto, member);
            var result = _memberRepository.Update(member);

            if (result)
            {
                await _memberRepository.SaveAsync();
                return new() { Message = "Profil bilgileri başarıyla güncellendi.", Success = true };
            }
                
            
            return new() {Message="HATA. Profil bilgileri güncellenemedi.", Success = false };
        }
    }
}
