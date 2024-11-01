using AutoMapper;
using MediatR;
using StayFit.Application.DTOs;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.Members.GetMemberProfile
{
    public class GetMemberProfileQueryHandler : IRequestHandler<GetMemberProfileQueryRequest, GetMemberProfileQueryResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetMemberProfileQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<GetMemberProfileQueryResponse> Handle(GetMemberProfileQueryRequest request, CancellationToken cancellationToken)
        {
            Member member = await _memberRepository.GetMemberProfileAsync(request.MemberId);
            MemberResponseDto memberResponseDto = _mapper.Map<MemberResponseDto>(member);

            return new() { MemberResponseDto = memberResponseDto };
        }
    }
}
