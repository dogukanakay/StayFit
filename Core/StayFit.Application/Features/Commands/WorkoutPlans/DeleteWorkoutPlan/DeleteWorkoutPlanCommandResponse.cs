namespace StayFit.Application.Features.Commands.WorkoutPlans.DeleteWorkoutPlan
{
    public class DeleteWorkoutPlanCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public DeleteWorkoutPlanCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
