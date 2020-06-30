using System;
using ThrowIf;
using Xunit;
using static System.String;

namespace Validators.Tests
{
    public class IsEmptyValidatorTests
    {
        [Fact]
        public void Guid_IsEmpty_Test()
        {
            // Arrange
            Guid guid = Guid.Empty;

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void Guid_IsNotEmpty_Test()
        {
            // Arrange
            Guid guid = Guid.NewGuid();

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void NullableGuid_IsEmpty_Test()
        {
            // Arrange
            Guid? guid = Guid.Empty;

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void NullableGuid_IsNotEmpty_Test()
        {
            // Arrange
            Guid? guid = Guid.NewGuid();

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void NullGuid_IsNotEmpty_Test()
        {
            // Arrange
            Guid? guid = null;

            // Act
            var isEmpty = guid.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void String_IsEmpty_Test()
        {
            // Arrange
            string str = Empty;

            // Act
            var isEmpty = str.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void String_IsNotEmpty_Test()
        {
            // Arrange
            string str = "string";

            // Act
            var isEmpty = str.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void NullString_IsNotEmpty_Test()
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