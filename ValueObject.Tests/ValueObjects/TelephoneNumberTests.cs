using FluentAssertions;
using NUnit.Framework;
using System;
using ValueObject.Domain.ValueObjects;
using ValueObject.Exceptions;

namespace ValueObjectTests
{
    public class TelephoneNumberTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void GivenNullOrEmptyStringShouldThrowArgumentNullException(string value)
        {
            // Arrange & Act
            Action act = () => TelephoneNumber.From(value);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'Value')");
        }

        [Test]
        public void GivenLongStringShouldThrowInvalidTelephoneNumberFormatException()
        {
            var value = new string('1', 13); //max is 12

            // Arrange & Act
            Action act = () => TelephoneNumber.From(value);

            // Assert
            act.Should().Throw<InvalidTelephoneNumberFormatException>()
                .WithMessage("Invalid telephone number format: 1111111111111. The value is too long.");
        }

        [Test]
        public void GivenShortStringShouldThrowInvalidTelephoneNumberFormatException()
        {
            var value = new string('1', 7); //min is 8

            // Arrange & Act
            Action act = () => TelephoneNumber.From(value);

            // Assert
            act.Should().Throw<InvalidTelephoneNumberFormatException>()
                .WithMessage("Invalid telephone number format: 1111111. The value is too short.");
        }

        [Test]
        public void GivenNonNumericStringShouldThrowInvalidTelephoneNumberFormatException()
        {
            var value = "01234 56789!";

            // Arrange & Act
            Action act = () => TelephoneNumber.From(value);

            // Assert
            act.Should().Throw<InvalidTelephoneNumberFormatException>()
                .WithMessage("Invalid telephone number format: 0123456789!. The value contains non numeric characters.");
        }

        [TestCase("01234567901")]
        [TestCase("01234 567901")]
        public void GivenValidStringShouldCreateValueObject(string value)
        {
            // Arrange & Act
            var act = TelephoneNumber.From(value);

            // Assert
            act.ToString().Should().Be("01234567901");
            act.Value.Should().Be("01234567901");
        }
    }
}