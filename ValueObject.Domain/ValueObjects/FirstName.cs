using System;
using ValueObject.Exceptions;
using ValueOf;

namespace ValueObject.ValueObjects
{
    public class FirstName : ValueOf<string, FirstName>
    {
        private const int MinLength = 1;
        private const int MaxLength = 15;

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new ArgumentNullException(nameof(Value));
            }

            if (Value.Length < MinLength)
            {
                throw new InvalidPostcodeFormatException(Value);
            }

            if (Value.Length > MaxLength)
            {
                throw new InvalidPostcodeFormatException(Value);
            }
        }
    }
}