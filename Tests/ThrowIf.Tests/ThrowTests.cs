using System;
using ThrowIf.Tests.Common;
using Xunit;

namespace ThrowIf.Tests
{
    public class ThrowTests
    {
        [Fact]
        public void Throw_WithMessageTemplate_Test()
        {
            // Arrange
            var expectedName = "name";
            Func<string, string> messageTemplate = name => name;

            Action action = () =>
                Throw.Exception(TestException.Factory).If(true, expectedName, messageTemplate);

            // Act + Assert
            var ex = Assert.Throws<TestException>(action);
            Assert.Equal(messageTemplate(expectedName), ex.Message);
        }

        [Fact]
        public void Throw_Test()
        {
            // Arrange
            Action action = () =>
                Throw.Exception(TestException.Factory).If(true, string.Empty);

            // Act + Assert
            Assert.Throws<TestException>(action);
        }
    }
}