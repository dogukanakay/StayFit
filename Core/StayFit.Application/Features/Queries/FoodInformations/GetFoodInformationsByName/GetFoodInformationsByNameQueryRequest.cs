using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.FoodInformations.GetFoodInformationsByName
{
    public class GetFoodInformationsByNameQueryRequest : IRequest<GetFoodInformationsByNameQueryResponse>
    {
        public string FoodName { get; }

        public GetFoodInformationsByNameQueryRequest(string foodName)
        {
            FoodName = foodName;
        }
    }
}
