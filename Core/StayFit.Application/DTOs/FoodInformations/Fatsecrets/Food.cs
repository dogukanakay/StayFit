using Newtonsoft.Json;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class Food
    {
        [JsonProperty("food_id")]
        public string FoodId { get; set; }

        [JsonProperty("food_name")]
        public string FoodName { get; set; }

        [JsonProperty("food_type")]
        public string FoodType { get; set; }

        [JsonProperty("food_url")]
        public string FoodUrl { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("food_images")]
        public FoodImages FoodImages { get; set; }

        [JsonProperty("servings")]
        public Servings Servings { get; set; }
    }
}