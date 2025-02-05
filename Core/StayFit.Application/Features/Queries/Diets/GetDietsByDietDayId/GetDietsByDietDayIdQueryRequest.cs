using MediatR;

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
