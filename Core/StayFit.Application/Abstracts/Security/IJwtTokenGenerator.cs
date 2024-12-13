using StayFit.Application.DTOs;
using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Security
{
    public interface IJwtTokenGenerator
    {
        public Task<TokenDto> GenerateToken(User user);
    }
}
