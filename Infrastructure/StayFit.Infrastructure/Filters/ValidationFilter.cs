using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StayFit.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument is null) continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
                var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

                if (validator != null)
                {
                    var validationContext = new ValidationContext<object>(argument);
                    ValidationResult result = await validator.ValidateAsync(validationContext);

                    if (!result.IsValid)
                    {
                        var errors = result.Errors.Select(e => new
                        {
                            Field = e.PropertyName,
                            Error = e.ErrorMessage
                        });

                        context.Result = new BadRequestObjectResult(new
                        {
                            Message = "Validation failed.",
                            Errors = errors
                        });

                        return;
                    }
                }
                
            }
            await next();
        }
    }
}
