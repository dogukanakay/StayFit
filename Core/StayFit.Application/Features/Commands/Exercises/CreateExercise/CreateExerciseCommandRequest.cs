﻿using MediatR;
using StayFit.Application.DTOs.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Exercises.CreateExercise
{
    public class CreateExerciseCommandRequest : IRequest<CreateExerciseCommandResponse>
    {
        public CreateExerciseDto CreateExerciseDto { get; set; }
    }
}