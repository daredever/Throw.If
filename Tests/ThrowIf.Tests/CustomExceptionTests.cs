using System;
using Xunit;

namespace ThrowIf.Tests
{
    public class CustomExceptionTests
    {
        [Fact]
        public void Throw_CustomException_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw.Exception<CustomExceptionFactory>()
                    .If(true, message);

            // Act + Assert
            var ex = Assert.Throws<CustomException>(action);
            Assert.Equal(message, ex.Message);
        }

        class CustomException : Exception
        {
            public CustomException(string message) : base(message)
            {
            }
        }
        
        class CustomExceptionFactory : IExceptionFactory
        {
            public Exception CreateInstance(string message) => new CustomException(message);
        }
    }
}