using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Exercises.GetTodaysExercisesByMemberId
{
    public class GetTodaysExercisesByMemberIdQueryRequest : IRequest<GetTodaysExercisesByMemberIdQueryResponse>
    {
        public Guid MemberId { get;}

        public GetTodaysExercisesByMemberIdQueryRequest(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
