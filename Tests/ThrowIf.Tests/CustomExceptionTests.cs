using System;
using Xunit;

namespace ThrowIf.Tests
{
    public class CustomExceptionTests
    {
        [Fact]
        public void Throw_CustomExceptionFactory_Generic_Test()
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
        
        [Fact]
        public void Throw_CustomExceptionFactory_Instance_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw.Exception(new CustomExceptionFactory())
                    .If(true, message);

            // Act + Assert
            var ex = Assert.Throws<CustomException>(action);
            Assert.Equal(message, ex.Message);
        }
        
        [Fact]
        public void Throw_CustomExceptionFactory_Delegate_Test()
        {
            // Arrange
            var message = "message";
            Action action = () =>
                Throw.Exception(msg => new CustomException(msg))
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