using System;

namespace ValueObject.Exceptions
{
    public class InvalidPostcodeFormatException : Exception
    {
        public InvalidPostcodeFormatException(string postcode) : base($"Invalid postcode format: {postcode}.")
        {
        }
    }
}