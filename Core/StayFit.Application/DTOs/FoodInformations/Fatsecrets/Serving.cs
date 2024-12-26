using Newtonsoft.Json;

namespace StayFit.Application.DTOs.FoodInformations.Fatsecrets
{
    public class Serving
    {
        [JsonProperty("serving_id")]
        public string ServingId { get; set; }

        [JsonProperty("serving_description")]
        public string ServingDescription { get; set; }

        [JsonProperty("metric_serving_amount")]
        public string MetricServingAmount { get; set; }

        [JsonProperty("metric_serving_unit")]
        public string MetricServingUnit { get; set; }

        [JsonProperty("number_of_units")]
        public string NumberOfUnits { get; set; }

        [JsonProperty("measurement_description")]
        public string MeasurementDescription { get; set; }

        [JsonProperty("calories")]
        public string Calories { get; set; }

        [JsonProperty("carbohydrate")]
        public string Carbohydrate { get; set; }

        [JsonProperty("protein")]
        public string Protein { get; set; }

        [JsonProperty("fat")]
        public string Fat { get; set; }

       
    }
}