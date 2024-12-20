using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Diets.UpdateDietByAI
{
    public class UpdateDietByAICommandRequest : IRequest<UpdateDietByAICommandResponse>
    {
        public int DietId { get;}
        public string Prompt { get; }

        public UpdateDietByAICommandRequest(int dietId, string prompt)
        {
            DietId = dietId;
            Prompt = prompt;
        }
    }
}
