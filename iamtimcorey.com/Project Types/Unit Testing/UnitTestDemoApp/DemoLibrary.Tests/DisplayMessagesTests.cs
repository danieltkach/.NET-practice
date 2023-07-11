/***************************/
// Arrange - Act - Assert
// expected vs actual
// Red, Green, Refactor 
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

        [Fact]
        public void GreetingShouldReturnGoodAfternooMessage()
        {
            // Arrange
            DisplayMessages messages = new DisplayMessages();
            string expected = "Good afternoon Dan";

            // Act
            string actual = messages.Greeting("Dan", 14);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Dan", 0, "Go to bed Dan")]
        [InlineData("Dan", 1, "Go to bed Dan")]
        [InlineData("Dan", 2, "Go to bed Dan")]
        [InlineData("Dan", 3, "Go to bed Dan")]
        [InlineData("Dan", 4, "Go to bed Dan")]
        [InlineData("Dan", 5, "Good morning Dan")]
        [InlineData("Dan", 6, "Good morning Dan")]
        [InlineData("Dan", 7, "Good morning Dan")]
        [InlineData("Dan", 8, "Good morning Dan")]
        [InlineData("Dan", 9, "Good morning Dan")]
        [InlineData("Dan", 10, "Good morning Dan")]
        [InlineData("Dan", 11, "Good morning Dan")]
        [InlineData("Dan", 12, "Good afternoon Dan")]
        [InlineData("Dan", 13, "Good afternoon Dan")]
        [InlineData("Dan", 14, "Good afternoon Dan")]
        [InlineData("Dan", 15, "Good afternoon Dan")]
        [InlineData("Dan", 16, "Good afternoon Dan")]
        [InlineData("Dan", 17, "Good afternoon Dan")]
        [InlineData("Dan", 18, "Good evening Dan")]
        [InlineData("Dan", 19, "Good evening Dan")]
        [InlineData("Dan", 20, "Good evening Dan")]
        [InlineData("Dan", 21, "Good evening Dan")]
        [InlineData("Dan", 22, "Good evening Dan")]
        [InlineData("Dan", 23, "Good evening Dan")]
        public void GreetingShouldReturnExpectedValue(
            string firstName,
            int hourOfTheDay,
            string expected)
        {
            // Arrange
            DisplayMessages messages = new DisplayMessages();

            // Act
            string actual = messages.Greeting(firstName, hourOfTheDay);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}