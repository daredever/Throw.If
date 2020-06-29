using System;
using Xunit;

namespace ThrowIf.Tests
{
    public class ConditionGroupTests
    {
        [Fact]
        public void Throw_ConditionGroup_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw.Exception<ArgumentExceptionFactory>()
                    .If(new MessageValidator(), message);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }

        class MessageValidator : IConditionGroup<string>
        {
            public void Verify(in ThrowContext context, string message)
            {
                context.If(true, message);
            }
        }
    }
}