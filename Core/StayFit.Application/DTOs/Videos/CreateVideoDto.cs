using StayFit.Application.DTOs.Abstracts;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Videos
{
    public record CreateVideoDto : IDto
    {
        public string Title { get; init; }
        public VideoPlatforms VideoPlatform { get; init; }
        public VideoTypes VideoType { get; init; }
        public string Url { get; init; }
        public int Priority { get; init; }


    }
}
