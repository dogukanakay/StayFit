using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Diets.DeleteDiet
{
    public class DeleteDietCommandRequest : IRequest<DeleteDietCommandResponse>
    {
        public int DietId { get;}

        public DeleteDietCommandRequest(int dietId)
        {
            DietId = dietId;
        }
    }
}
