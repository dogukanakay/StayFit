namespace StayFit.Application.Features.Commands.WorkoutPlans.UpdateWorkoutPlan
{
    public class UpdateWorkoutPlanCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public UpdateWorkoutPlanCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
