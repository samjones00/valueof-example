using System;

namespace ValueObject.Exceptions
{
    public class InvalidTelephoneNumberFormatException : Exception
    {
        public InvalidTelephoneNumberFormatException(string value, string message) : base($"Invalid telephone number format: {value}. {message}")
        {
        }
    }
}