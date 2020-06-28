using System;
using ThrowIf;
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
                Throw<ArgumentExceptionFactory>
                    .If(true, message);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }

        [Fact]
        public void Throw_WithMessage_Ext_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw<ArgumentExceptionFactory>
                    .If(false, string.Empty)
                    .If(true, message);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }

        [Fact]
        public void Throw_WithMessageTemplate_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw<ArgumentExceptionFactory>
                    .If(true, () => message);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }

        [Fact]
        public void Throw_WithMessageTemplate_Ext_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw<ArgumentExceptionFactory>
                    .If(false, () => string.Empty)
                    .If(true, () => message);

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, ex.Message);
        }
    }
}