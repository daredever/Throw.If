using System;
using ThrowIf;
using static ThrowIf.MessageTemplates;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "msg";
            Assert(message, Guid.Empty);

            Console.WriteLine("Hello World!");
        }

        private static void Assert(string? message, Guid? guid)
        {
            try
            {
                Throw<ArgumentNullExceptionFactory>
                    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: CanNotBeNull)
                    .If(condition: message.IsNull(), name: nameof(message), messageTemplate: CanNotBeNull);

                Throw<ValidationExceptionFactory>
                    .If(condition: guid.IsEmpty(), name: nameof(guid), messageTemplate: CanNotBeEmpty)
                    .If(condition: message.IsEmpty(), name: nameof(message), messageTemplate: CanNotBeEmpty)
                    .If(message.Length > 10, $"{nameof(message.Length)} is not valid");

                Throw<CustomException>
                    .If(conditionGroup: MessageValidator.Instance, value: message);

                PrintMessage(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Test:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}