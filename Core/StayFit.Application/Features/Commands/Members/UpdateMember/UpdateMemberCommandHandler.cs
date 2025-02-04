using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
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
            _memberRepository.Update(member);


            int result = await _memberRepository.SaveAsync();

            return result > 0 ? new(Messages.MemberProfileUpdatedSuccessful, true) : new(Messages.MemberProfileUpdatedFailed, false);
            
        }
    }
}
