using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Exceptions.Auths
{
    public class EmailAlreadyExistException : Exception
    {
        public EmailAlreadyExistException() : base("Bu email ile zaten bir kayıt mevcut.")
        {
        }

        public EmailAlreadyExistException(string? message) : base(message)
        {

        }

        public EmailAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

    }
}
