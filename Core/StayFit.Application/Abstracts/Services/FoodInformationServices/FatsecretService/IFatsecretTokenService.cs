using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Services.FoodInformationServices.FatsecretService
{
    public interface IFatsecretTokenService
    {
        Task<string> GetAccessTokenAsync();
    }
}
