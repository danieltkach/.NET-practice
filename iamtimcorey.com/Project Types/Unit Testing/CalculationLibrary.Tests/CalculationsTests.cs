using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculationLibrary.Tests
{
    public class CalculationsTests
    {
        [Theory]
        [InlineData(4, 2, 6)]
        [InlineData(-1, -2, -3)]
        [InlineData(0, 0, 0)]
        [InlineData(5, 0, 5)]
        public void AddShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations calc = new Calculations();

            // Act
            double actual = calc.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 2, 8)]
        [InlineData(-1, -2, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(5, 0, 5)]
        public void SubtractShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations calc = new Calculations();

            // Act
            double actual = calc.Subtract(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 2, 20)]
        [InlineData(-1, -2, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(5, 0, 0)]
        public void MultiplyShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations calc = new Calculations();

            // Act
            double actual = calc.Multiply(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(-1, -2, 0.5)]
        [InlineData(0, 0, 0)]
        [InlineData(5, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 9, 0)]
        public void DivideShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations calc = new Calculations();

            // Act
            double actual = calc.Divide(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
