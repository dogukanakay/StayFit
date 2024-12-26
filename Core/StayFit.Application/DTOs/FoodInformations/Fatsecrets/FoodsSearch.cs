using Newtonsoft.Json;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class FoodsSearch
    {
        [JsonProperty("max_results")]
        public string MaxResults { get; set; }

        [JsonProperty("total_results")]
        public string TotalResults { get; set; }

        [JsonProperty("page_number")]
        public string PageNumber { get; set; }

        [JsonProperty("results")]
        public Results Results { get; set; }
    }
}