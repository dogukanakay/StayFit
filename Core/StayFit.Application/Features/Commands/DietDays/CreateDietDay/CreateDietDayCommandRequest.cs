﻿using MediatR;
using StayFit.Application.DTOs.DietDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.DietDays.CreateDietDay
{
    public class CreateDietDayCommandRequest : IRequest<CreateDietDayCommandResponse>
    {
        public CreateDietDayDto CreateDietDayDto { get; }
        public Guid TrainerId { get;}

        public CreateDietDayCommandRequest(CreateDietDayDto createDietDayDto, Guid trainerId)
        {
            CreateDietDayDto = createDietDayDto;
            TrainerId = trainerId;
        }
    }
}
