using StayFit.Application.Constants.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Exceptions.Auths
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(ExceptionMessages.UserNotFound)
        {

        }

        public UserNotFoundException(string? message) : base(message)
        {

        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
