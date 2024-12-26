using Newtonsoft.Json;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class FoodImage
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("image_type")]
        public string ImageType { get; set; }
    }
}