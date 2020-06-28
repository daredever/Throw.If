using System;
using ThrowIf;
using Xunit;
using static System.String;

namespace Validators.Tests
{
    public class IsEmptyValidatorTests
    {
        [Fact]
        public void GuidIsEmpty_Test()
        {
            // Arrange
            Guid guid = Guid.Empty;

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }
        
        [Fact]
        public void GuidIsNotEmpty_Test()
        {
            // Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }
        
        [Fact]
        public void NullableGuidIsEmpty_Test()
        {
            // Arrange
            Guid? guid = Guid.Empty;

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }
        
        [Fact]
        public void NullableGuidIsNotEmpty_Test()
        {
            // Arrange
            Guid? guid = Guid.NewGuid();

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }
        
        [Fact]
        public void NullGuidIsNotEmpty_Test()
        {
            // Arrange
            Guid? guid = null;

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }
        
        [Fact]
        public void StringIsEmpty_Test()
        {
            // Arrange
            string str = Empty;

            // Act
            var isEmpty = str.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }
        
        [Fact]
        public void StringIsNotEmpty_Test()
        {
            // Arrange
            string str = "string";

            // Act
            var isEmpty = str.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }
        
        [Fact]
        public void NullStringIsNotEmpty_Test()
        {
            // Arrange
            string? str = null;

            // Act
            var isEmpty = str.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }
    }
}