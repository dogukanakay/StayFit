using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Members.GetMemberProfile
{
    public class GetMemberProfileQueryRequest : IRequest<GetMemberProfileQueryResponse>
    {
        public Guid MemberId { get; set; }
    }
}
