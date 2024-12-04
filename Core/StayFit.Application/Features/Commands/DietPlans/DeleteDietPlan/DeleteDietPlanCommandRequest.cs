﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.DietPlans.DeleteDietPlan
{
    public class DeleteDietPlanCommandRequest : IRequest<DeleteDietPlanCommandResponse>
    {
        public int DietPlanId { get; }

        public DeleteDietPlanCommandRequest(int dietPlanId)
        {
            DietPlanId = dietPlanId;
        }

    }
}
