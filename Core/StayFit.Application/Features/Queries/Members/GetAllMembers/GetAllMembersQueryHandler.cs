using AutoMapper;
using MediatR;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Members.GetAllMembers
{
    public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQueryRequest, GetAllMembersQueryResult>
    {
        private readonly IMemberRepository _memberRepository;
        private IMapper _mapper;

        public GetAllMembersQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<GetAllMembersQueryResult> Handle(GetAllMembersQueryRequest request, CancellationToken cancellationToken)
        {
            List<Member> members = await _memberRepository.GetAllMembersIncludeUserAsync();
            List<MemberResponseDto> memberResponseDtos = _mapper.Map<List<MemberResponseDto>>(members);

            return new(memberResponseDtos);
        }
    }
}
