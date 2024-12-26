using Newtonsoft.Json;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class Results
    {
        [JsonProperty("food")]
        public List<Food> Food { get; set; }
    }
}