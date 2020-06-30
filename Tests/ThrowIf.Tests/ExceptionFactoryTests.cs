using System;
using ThrowIf.Tests.Common;
using Xunit;

namespace ThrowIf.Tests
{
    public class ExceptionFactoryTests
    {
        [Fact]
        public void Throw_ExceptionFactory_Test()
        {
            // Arrange
            var expectedName = "name";
            var messageTemplate = MessageTemplates.IsNotValid;
            Action action = () =>
                Throw.Exception(TestException.Factory, messageTemplate).If(true, expectedName);

            // Act + Assert
            var ex = Assert.Throws<TestException>(action);
            Assert.Equal(messageTemplate(expectedName), ex.Message);
        }
    }
}