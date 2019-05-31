using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Main.Tests
{
    public class InputReaderTest
    {
        [Theory]
        [InlineData("C:\\Source", "C:\\Destination", "doc,exe", "Copy")]
        [InlineData("C:\\Source", "C:\\Destination", "", "Search")]
        public void InputReader_ShouldWorkCorrectly(string source = null, string destination = null,
            string filter = null, string operation = null)
        {
            // Arrange
            string[] args = new[] {source, destination, filter, operation};

            // Act
            IInput reader = new InputReader();
            IEnumerable<Argument> arguments = reader.Read(args);

            // Assert
            Assert.NotNull(arguments);

            Assert.Equal(source, arguments.First(x => x.Name == "Input").Value);
            Assert.Equal(destination, arguments.First(x => x.Name == "Output").Value);
            Assert.Equal(filter, arguments.First(x => x.Name == "Filter").Value);
            Assert.Equal(operation, arguments.First(x => x.Name == "OperationType").Value);
        }
        
        [Theory]
        [InlineData("C:\\Source,C:\\Destination,Copy")]
        [InlineData("C:\\Source,Search")]
        public void InputReader_ShouldThrowArgumentOutOfRangeException(string arguments)
        {
            // Arrange
            string[] args = arguments.Split(',');

            // Act
            InputReader reader = new InputReader();
            var test = reader.Read(args);
            Action act = () => Assert.Equal("Input", test.First().Name);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(null)]
        public void InputReader_ShouldThrowArgumentNullException(string[] args)
        {
            // Act
            InputReader reader = new InputReader();
            var test = reader.Read(args);
            Action act = () => Assert.Equal("Input", test.First().Name);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData("C:\\Source,C:\\Destination,,")]
        public void InputReader_ShouldThrowArgumentException(string args)
        {
            // Arrange
            string[] arguments = args.Split(',');

            // Act
            InputReader reader = new InputReader();
            var test = reader.Read(arguments);
            Action act = () => Assert.Equal("Input", test.First().Name);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}