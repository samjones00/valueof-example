using FluentAssertions;
using NUnit.Framework;
using System;
using ValueObject.Exceptions;
using ValueObject.ValueObjects;

namespace ValueObjectTests
{
    public class PostcodeTests
    {
        [Test]
        public void GivenEmptyStringShouldThrowArgumentNullException()
        {
            // Arrange & Act
            Action act = () => Postcode.From(string.Empty);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'Value')");
        }

        [Test]
        public void GivenLongStringShouldThrowInvalidPostcodeFormatException()
        {
            // Arrange & Act
            Action act = () => Postcode.From("abcd");

            // Assert
            act.Should().Throw<InvalidPostcodeFormatException>()
                .WithMessage("Invalid postcode format: abcd.");
        }

        [Test]
        public void GivenValidStringShouldCreateValueObject()
        {
            // Arrange & Act
            var act = Postcode.From("abcd efg");

            // Assert
            act.Value.Should().Be("abcd efg");
        }
    }
}