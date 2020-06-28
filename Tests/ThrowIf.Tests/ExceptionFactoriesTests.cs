using System;
using System.ComponentModel.DataAnnotations;
using ThrowIf;
using Xunit;

namespace ThrowIf.Tests
{
    public class ExceptionFactoriesTests
    {
        [Theory]
        [InlineData(typeof(ArgumentExceptionFactory), "message", typeof(ArgumentException))]
        [InlineData(typeof(ArgumentNullExceptionFactory), "message", typeof(ArgumentNullException))]
        [InlineData(typeof(ValidationExceptionFactory), "message", typeof(ValidationException))]
        [InlineData(typeof(ArgumentExceptionFactory), "asdfasdf", typeof(ArgumentException))]
        [InlineData(typeof(ArgumentNullExceptionFactory), "asdfasdf", typeof(ArgumentNullException))]
        [InlineData(typeof(ValidationExceptionFactory), "asdfasdf", typeof(ValidationException))]
        public void ExceptionFactory_Test(Type factoryType, string message, Type exceptionType)
        {
            // Arrange
            var factory = (IExceptionFactory) Activator.CreateInstance(factoryType);

            // Act
            var exception = factory?.CreateInstance(message);

            // Assert
            Assert.IsType(exceptionType, exception);
            Assert.Equal(message, exception.Message);
        }
    }
}