using Microsoft.EntityFrameworkCore;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
using StayFit.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.Repositories
{
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        private readonly StayFitDbContext _context;
        public VideoRepository(StayFitDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Video>> GetVideosByVideoType(VideoTypes videoType)
            => await _context.Videos.Where(v => v.VideoType == videoType).AsNoTracking().ToListAsync();

    }
}
