﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs
{
    public record LoginDto
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
