using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class FoodSearchResult
    {
        [JsonProperty("foods_search")]
        public FoodsSearch FoodsSearch { get; set; }
    }
}