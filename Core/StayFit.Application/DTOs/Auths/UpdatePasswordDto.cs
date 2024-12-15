using StayFit.Application.DTOs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.DTOs.Auths
{
    public record UpdatePasswordDto : IDto
    {
        public string CurrentPassword { get; }
        public string NewPassword { get;}

        public UpdatePasswordDto(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
