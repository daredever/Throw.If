using System;
using ThrowIf;
using ThrowIf.Exceptions;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Verify(text: "msg", guid: Guid.Empty);
        }

        private static void Verify(string? text, Guid? guid)
        {
            try
            {
                Throw<ArgumentExceptionFactory>
                    .If(condition: guid.IsNull(), name: nameof(guid), messageTemplate: MessageTemplates.CanNotBeNull)
                    .If(condition: text.IsNull(), name: nameof(text), messageTemplate: MessageTemplates.CanNotBeNull)
                    .If(conditionGroup: new TextValidator(), value: text);

                PrintMessage(text);
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