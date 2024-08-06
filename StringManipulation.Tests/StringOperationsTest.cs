using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact(Skip = "Test")]
        public void ConcatenateStrings()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");
            
            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.RemoveWhitespace("Hello Platzi");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("HelloPlatzi", result);
        }

        [Fact]
        public void GetStringLength_NullException()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.GetStringLength("Hello");

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(5, result);

        }

        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Hello Platzi", 'l', 3)]
        [InlineData("Hello World", 'o', 2)]
        public void CountOccurrences(string myString, char c, int expected)
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            // Act
            var result = strOperations.CountOccurrences(myString, c);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("hello");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("cat", 10);

            // Assert
            Assert.StartsWith("ten", result);
            Assert.Contains("cat", result);
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        [InlineData("XV", 15)]
        [InlineData("VI", 6)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.FromRomanToNumber(romanNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadFile()
        {
            // Arrange
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            var message = "Reading File";
            mockFileReader.Setup(f => f.ReadString(It.IsAny<string>())).Returns(message);

            // Act
            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            // Assert
            Assert.Equal(message, result);
        }

    }

}
