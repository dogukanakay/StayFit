namespace StayFit.Application.Features.Commands.DietPlans.CreateDietPlan
{
    public class CreateDietPlanCommandResponse
    {
        public string Message { get; }
        public bool Success { get; }

        public CreateDietPlanCommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
