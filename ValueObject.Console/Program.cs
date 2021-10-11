using ValueObject.Domain.ValueObjects;

namespace ValueObject.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tooLong = TelephoneNumber.From("12345 6789012345"); // throws exception
            var tooShort = TelephoneNumber.From("12345"); // throws exception
            var invalidCharacters = TelephoneNumber.From("telephone no"); // throws exception

            var validTelephoneNumber = TelephoneNumber.From("01234 567890"); //all good

            // Do business stuff...
        }
    }
}