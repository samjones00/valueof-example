using System;

namespace ValueObject.Exceptions
{
    public class InvalidPostcodeFormatException : Exception
    {
        public InvalidPostcodeFormatException(string value) : base($"Invalid postcode format: {value}.")
        {
        }
    }
}