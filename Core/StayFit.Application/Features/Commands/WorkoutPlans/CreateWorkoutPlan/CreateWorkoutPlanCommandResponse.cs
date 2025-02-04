namespace StayFit.Application.Features.Commands.WorkoutPlans.CreateWorkoutPlan
{
    public class CreateWorkoutPlanCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public CreateWorkoutPlanCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
