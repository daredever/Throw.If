using System;
using ThrowIf.Tests.Common;
using Xunit;

namespace ThrowIf.Tests
{
    public class ConditionGroupTests
    {
        [Fact]
        public void Throw_ConditionGroup_Test()
        {
            // Arrange
            var text = "text";
            var messageTemplate = MessageTemplates.IsNotValid;
            Action action = () =>
                Throw.Exception(TestException.Factory, messageTemplate).If(new TextValidator(), text);

            // Act + Assert
            var ex = Assert.Throws<TestException>(action);
            Assert.Equal(messageTemplate(text), ex.Message);
        }

        private class TextValidator : IConditionGroup<string>
        {
            public void Verify(in ThrowContext context, string text)
            {
                context.If(true, nameof(text));
            }
        }
    }
}