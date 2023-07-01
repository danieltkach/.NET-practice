/***************************/
// Arrange - Act - Assert //
/***************************/

namespace DemoLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GreetingShouldReturnGoodMorningMessage()
        {
            // Arrange
            DisplayMessages messages = new DisplayMessages();
            string expected = "Good morning Dan";

            // Act
            string actual = messages.Greeting("Dan", 6);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}