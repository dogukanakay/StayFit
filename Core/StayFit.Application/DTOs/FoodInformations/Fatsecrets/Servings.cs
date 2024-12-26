using Newtonsoft.Json;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class Servings
    {
        [JsonProperty("serving")]
        public List<Serving> Serving { get; set; }
    }
}