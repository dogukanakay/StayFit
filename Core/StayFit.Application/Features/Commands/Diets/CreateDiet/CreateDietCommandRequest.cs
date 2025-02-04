using MediatR;
using StayFit.Application.DTOs.Diets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.Diets.CreateDiet
{
    public class CreateDietCommandRequest : IRequest<CreateDietCommandResponse>
    {
        public List<CreateDietDto> CreateDietDtos { get;}

        public CreateDietCommandRequest(List<CreateDietDto> createDietDtos)
        {
            CreateDietDtos = createDietDtos;
        }
    }
}
