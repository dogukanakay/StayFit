using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record TokenDto
    {
        public string Token { get; init; }
        public DateTime Expires { get; set; }

    }
}
