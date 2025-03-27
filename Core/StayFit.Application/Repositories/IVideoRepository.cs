using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Repositories
{
    public interface IVideoRepository : IGenericRepository<Video>
    {
        Task<List<Video>> GetVideosByVideoType(VideoTypes videoType);
    }
}
