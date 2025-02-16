using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Constants.Messages
{
    public static class ExceptionMessages
    {
        
        public const string UserNotFound = "User not found.";
        

        public const string EmailAlreadyExist = "Email already exist";
       
        public const string PhoneAlreadyExist = "Phone already exist";

        public const string PhotoCannotBeEmpty = "Photo can not be empty.";

        public const string ForbiddenAccess = "You do not have access to perform this action.";

    }
}
