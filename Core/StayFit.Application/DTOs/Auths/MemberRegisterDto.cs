using StayFit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record MemberRegisterDto : RegisterDto
    {
        public int Height { get; init; }
        public float Weight { get; init; }

    }
}
