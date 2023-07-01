/***************************/
// Arrange - Act - Assert //
/***************************/

namespace DemoLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            DisplayMessages messages = new DisplayMessages();
            string expected = "Good Morning Dan";

            // Act
            string actual = messages.Greeting("Dan", 23);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}