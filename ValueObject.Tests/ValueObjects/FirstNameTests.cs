using FluentAssertions;
using NUnit.Framework;
using System;
using ValueObject.Exceptions;
using ValueObject.ValueObjects;

namespace ValueObjectTests
{
    public class FirstNameTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void GivenNullOrEmptyStringShouldThrowArgumentNullException(string name)
        {
            // Arrange & Act
            Action act = () => FirstName.From(name);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'Value')");
        }

        [Test]
        public void GivenLongStringShouldThrowInvalidPostcodeFormatException()
        {
            var name = new string('a', 16); //max is 15

            // Arrange & Act
            Action act = () => FirstName.From(name);

            // Assert
            act.Should().Throw<InvalidPostcodeFormatException>()
                .WithMessage("Invalid postcode format: aaaaaaaaaaaaaaaa.");
        }

        [Test]
        public void GivenValidStringShouldCreateValueObject()
        {
            // Arrange & Act
            var act = FirstName.From("Steve Jobs");

            // Assert
            act.ToString().Should().Be("Steve Jobs");
            act.Value.Should().Be("Steve Jobs");
        }
    }
}