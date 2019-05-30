using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;
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

            Assert.Equal("Input", arguments.ElementAt(0).Name);
            Assert.Equal(source, arguments.ElementAt(0).Value);
            
            Assert.Equal("Output", arguments.ElementAt(1).Name);
            Assert.Equal(destination, arguments.ElementAt(1).Value);
            
            Assert.Equal("Filter", arguments.ElementAt(2).Name);
            Assert.Equal(filter, arguments.ElementAt(2).Value);

            Assert.Equal("OperationType", arguments.ElementAt(3).Name);
            Assert.Equal(operation, arguments.ElementAt(3).Value);
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
            Action act = () => Assert.Equal("Input", test.ElementAt(0).Name);

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
            Action act = () => Assert.Equal("Input", test.ElementAt(0).Name);

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
            Action act = () => Assert.Equal("Input", test.ElementAt(0).Name);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}