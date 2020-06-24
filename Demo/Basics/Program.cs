using System;
using ThrowIf;

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
                Throw<ArgumentExceptionFactory>
                    .If(
                        condition: false,
                        message: "message0")
                    .If(
                        condition: guid.IsNull(),
                        message: "message1")
                    .If(
                        condition: message.IsNull(),
                        name: nameof(ArgumentNullExceptionFactory),
                        messageTemplate: MessageTemplates.CanNotBeNull)
                    .If(
                        conditionGroup: StringConditionGroup.Instance,
                        value: message)
                    .If(
                        condition: message.IsEmpty(),
                        name: nameof(message),
                        messageTemplate: MessageTemplates.CanNotBeEmpty);

                PrintMessage(message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test: {nameof(ArgumentExceptionFactory)}");
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