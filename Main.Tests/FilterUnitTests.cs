using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Main.Tests
{
    public class FilterUnitTests
    {
        private IEnumerable<Argument> arguments = new List<Argument>
        {
            new Argument("Input", "C:\\source"), 
            new Argument("Output", "C:\\Destination"),
            new Argument("Filter", ""),
            new Argument("OperationType", "Move")
        };

        [Fact]
        public void Filter_ShouldWorkCorrectly()
        {
            // Arrange
            arguments.First(x => x.Name == "Filter").Value = "document";

            // Act
            IFilter filter = new Filter(arguments);
            

            // Assert
            Assert.NotNull(filter);
            Assert.NotNull(filter.Types);
            Assert.Equal("document", filter.Types);
        }

        [Fact]
        public void Filter_ShouldThrowArgumentNullException()
        {
            // Arrange
            IEnumerable<Argument> arguments = null;

            // Act
            Action act = () => new Filter(arguments);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Filter_ShouldBeEmpty()
        {

            // Act
            IFilter filter = new Filter(arguments);

            Assert.NotNull(filter);
            Assert.Null(filter.Types);
        }
    }
}
