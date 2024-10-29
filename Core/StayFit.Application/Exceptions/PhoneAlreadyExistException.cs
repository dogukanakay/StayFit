namespace StayFit.Application.Exceptions
{
    public class PhoneAlreadyExistException : Exception
    {

        public PhoneAlreadyExistException() : base("Bu telefon ile zaten bir kayıt mevcut.")
        {
        }

        public PhoneAlreadyExistException(string? message) : base(message)
        {

        }

        public PhoneAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
