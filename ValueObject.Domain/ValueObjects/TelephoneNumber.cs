using System;
using System.Text.RegularExpressions;
using ValueObject.Exceptions;
using ValueOf;

namespace ValueObject.Domain.ValueObjects
{
    public class TelephoneNumber : ValueOf<string, TelephoneNumber>
    {
        private const int MinLength = 8;
        private const int MaxLength = 12;

        private const string NumbersOnlyRegex = "^[0-9]*$";
        private const string SpaceCharacterRegex = @"\s";

        protected override void Validate()
        {
         
            if (string.IsNullOrEmpty(Value))
            {
                throw new ArgumentNullException(nameof(Value));
            }

            if (Value.Length < MinLength)
            {
                throw new InvalidTelephoneNumberFormatException(Value, "The value is too short.");
            }

            if (Value.Length > MaxLength)
            {
                throw new InvalidTelephoneNumberFormatException(Value, "The value is too long.");
            }

            Value = Regex.Replace(Value, SpaceCharacterRegex, string.Empty); // removes spaces

            if (!Regex.IsMatch(Value, NumbersOnlyRegex))
            {
                throw new InvalidTelephoneNumberFormatException(Value, "The value contains non numeric characters.");
            }
        }
    }
}
