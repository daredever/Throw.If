using Xunit;

namespace ThrowIf.Tests
{
    public class MessageTemplatesTests
    {
        [Theory]
        [InlineData("name")]
        [InlineData("name2")]
        [InlineData("name3")]
        public void CanNotBeNull_Test(string name)
        {
            // Arrange
            var expectedMessage = $"{name} can not be null";

            // Act
            var messageFromTemplate = MessageTemplates.CanNotBeNull(name);

            // Assert
            Assert.Equal(expectedMessage, messageFromTemplate);
        }
        
        [Theory]
        [InlineData("name")]
        [InlineData("name2")]
        [InlineData("name3")]
        public void CanNotBeEmpty_Test(string name)
        {
            // Arrange
            var expectedMessage = $"{name} can not be empty";

            // Act
            var messageFromTemplate = MessageTemplates.CanNotBeEmpty(name);

            // Assert
            Assert.Equal(expectedMessage, messageFromTemplate);
        }
    }
}