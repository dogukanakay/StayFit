namespace StayFit.Application.Features.Commands.DietPlans.DeleteDietPlan
{
    public class DeleteDietPlanCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public DeleteDietPlanCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
