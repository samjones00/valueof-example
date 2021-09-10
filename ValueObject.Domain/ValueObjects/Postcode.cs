using System;
using ValueObject.Exceptions;
using ValueOf;

namespace ValueObject.Models
{
    public class Postcode : ValueOf<string, Postcode>
    {
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new ArgumentNullException(nameof(Value));
            }

            if (Value.Length < 5)
            {
                throw new InvalidPostcodeFormatException(Value);
            }
        }
    }
}