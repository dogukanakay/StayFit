using Newtonsoft.Json;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class FoodImages
    {
        [JsonProperty("food_image")]
        public List<FoodImage> FoodImage { get; set; }
    }
}