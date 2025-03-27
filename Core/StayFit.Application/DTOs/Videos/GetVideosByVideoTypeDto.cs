using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Videos
{
    public record GetVideosByVideoTypeDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public VideoPlatforms VideoPlatform { get; init; }
        public VideoTypes VideoType { get; init; }
        public string Url { get; init; }
        public int Priority { get; init; }

    }
}
