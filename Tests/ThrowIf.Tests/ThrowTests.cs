using System;
using Xunit;

namespace ThrowIf.Tests
{
    public class ThrowTests
    {
        [Fact]
        public void Throw_WithMessage_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw.Exception<ArgumentExceptionFactory>()
                    .If(true, message);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }

        [Fact]
        public void Throw_WithMessage_Second_Test()
        {
            // Arrange
            var message1 = "message1";
            var message2 = "message2";
            Action action = () =>
                Throw.Exception<ArgumentExceptionFactory>()
                    .If(false, message1)
                    .If(true, message2);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message2, ex.Message);
        }

        [Fact]
        public void Throw_WithMessageTemplate_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw.Exception<ArgumentExceptionFactory>()
                    .If(true, () => message);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }

        [Fact]
        public void Throw_WithNamedMessageTemplate_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw.Exception<ArgumentExceptionFactory>()
                    .If(true, message, name => name);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }
    }
}