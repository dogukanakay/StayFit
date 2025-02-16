using StayFit.Application.Constants.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Commons.Exceptions.Auths
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base(ExceptionMessages.ForbiddenAccess)
        {
        }

        public ForbiddenAccessException(string? message) : base(message)
        {
        }

        public ForbiddenAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        
    }
}
