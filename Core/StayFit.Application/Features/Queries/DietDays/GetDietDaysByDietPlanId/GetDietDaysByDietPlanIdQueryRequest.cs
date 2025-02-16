using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.DietDays.GetDietDaysByDietPlanId
{
    public class GetDietDaysByDietPlanIdQueryRequest : IRequest<GetDietDaysByDietPlanIdQueryResponse>
    {
        public int DietPlanId { get;}
        public Guid UserId { get;}

        public GetDietDaysByDietPlanIdQueryRequest(int dietPlanId, Guid userId)
        {
            DietPlanId = dietPlanId;
            UserId = userId;
        }
    }
}
