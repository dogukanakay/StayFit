using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Queries.Trainers.GetTrainerProfile
{
    public class GetTrainerProfileQueryRequest : IRequest<GetTrainerProfileQueryResponse>
    {
        public Guid TrainerId { get; set; }
    }
}
