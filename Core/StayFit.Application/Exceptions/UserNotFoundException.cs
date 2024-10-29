using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Bu bilgilerde kayıtlı bir kullanıcı bulunmamaktadır.")
        {
            
        }

        public UserNotFoundException(string? message): base(message)
        {
            
        }

        public UserNotFoundException(string? message, Exception? innerException): base(message, innerException) 
        {
            
        }
    }
}
