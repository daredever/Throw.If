using ThrowIf;
using Xunit;

namespace Validators.Tests
{
    public class IsNullValidatorTests
    {
        [Fact]
        public void String_IsNull_Test()
        {
            // Arrange
            string? str = null;

            // Act
            var isNull = str.IsNull();

            // Assert
            Assert.True(isNull);
        }

        [Fact]
        public void String_IsNotNull_Test()
        {
            // Arrange
            string? str = "string";

            // Act
            var isNull = str.IsNull();

            // Assert
            Assert.False(isNull);
        }

        [Fact]
        public void Int_IsNull_Test()
        {
            // Arrange
            int? value = null;

            // Act
            var isNull = value.IsNull();

            // Assert
            Assert.True(isNull);
        }

        [Fact]
        public void Int_IsNotNull_Test()
        {
            // Arrange
            int? value = 1;

            // Act
            var isNull = value.IsNull();

            // Assert
            Assert.False(isNull);
        }
    }
}