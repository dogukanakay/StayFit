using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Exercises.DeleteExercise
{
    public class DeleteExerciseCommandRequest : IRequest<DeleteExerciseCommandResponse>
    {
        public int ExerciseId { get;}

        public DeleteExerciseCommandRequest(int exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }
}
