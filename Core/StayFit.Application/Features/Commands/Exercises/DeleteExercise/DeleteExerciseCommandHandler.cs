using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Exercises.DeleteExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommandRequest, DeleteExerciseCommandResponse>
    {
        private readonly IExerciseRepository _exerciseRepository;

        public DeleteExerciseCommandHandler(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<DeleteExerciseCommandResponse> Handle(DeleteExerciseCommandRequest request, CancellationToken cancellationToken)
        {
            Exercise exercise = await _exerciseRepository.GetByIdAsync(request.ExerciseId, tracking: false);
            if (exercise == null)
                return new(Messages.ExerciseNotFound, false);
            await _exerciseRepository.Remove(exercise);
            int result = await _exerciseRepository.SaveAsync();

            return result > 0 ? new(Messages.ExerciseDeletedSuccessful, true) : new(Messages.ExerciseDeletedFailed, false);

        }
    }
}
