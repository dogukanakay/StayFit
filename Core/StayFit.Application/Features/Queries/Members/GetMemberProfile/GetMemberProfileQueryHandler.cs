using AutoMapper;
using MediatR;
using StayFit.Application.Commons.CustomAttributes.Caching;
using StayFit.Application.Constants.Messages;
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

        [Cache("profiles_{MemberId}", 1000)]
        public async Task<GetMemberProfileQueryResponse> Handle(GetMemberProfileQueryRequest request, CancellationToken cancellationToken)
        {
            Member member = await _memberRepository.GetMemberProfileAsync(request.MemberId);
            if (member is null)
                return new(Messages.MemberProfileNotFound, false, null);
            MemberResponseDto memberResponseDto = _mapper.Map<MemberResponseDto>(member);

            return new(Messages.MemberProfileLoadedSuccessful, true, memberResponseDto);
        }
    }
}
