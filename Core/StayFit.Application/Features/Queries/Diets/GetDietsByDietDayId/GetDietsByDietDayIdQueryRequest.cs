using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Diets.GetDietsByDietDayId
{
    public class GetDietsByDietDayIdQueryRequest : IRequest<GetDietsByDietDayIdQueryResponse>
    {
        public int DietDayId { get;}

        public GetDietsByDietDayIdQueryRequest(int dietDayId)
        {
            DietDayId = dietDayId;
        }
    }
}
