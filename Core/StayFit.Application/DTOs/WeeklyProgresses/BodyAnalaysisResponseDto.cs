using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StayFit.Application.DTOs.WeeklyProgresses
{
    

    public record BodyAnalaysisResponseDto
    {
        [JsonPropertyName("height")]
        public float Height { get; init; }

        [JsonPropertyName("neck circumference")]
        public float NeckCircumference { get; init; }

        [JsonPropertyName("waist circumference")]
        public float WaistCircumference { get; init; }

        [JsonPropertyName("chest circumference")]
        public float ChestCircumference { get; init; }

        [JsonPropertyName("hip circumference")]
        public float HipCircumference { get; init; }
    }
}
