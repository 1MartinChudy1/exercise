using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Main.Tests
{
    public class FilterUnitTests
    {
        [Fact]
        public void Filter_ShouldWorkCorrectly()
        {
            // Arrange
            IEnumerable<Argument> arguments = new List<Argument>
            {
                new Argument("Input", "C:\\source"), 
                new Argument("Output", "C:\\Destination"),
                new Argument("Filter", "c,cpp,cs"),
                new Argument("OperationType", "Move")
            };

            // Act
            IEnumerable<string> filterArgument = arguments.ElementAt(2)?.Value.Split(',');
            IFilter filter = new Filter(arguments);
            

            // Assert
            Assert.NotNull(filter);
            Assert.NotNull(filter.Types);
            for (int i = 0; i < filter.Types.Count() - 1; i++)
            {
                Assert.Equal(filterArgument.ElementAt(i), filter.Types.ElementAt(i));
            }
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
            // Arrange
            IEnumerable<Argument> arguments = new List<Argument>
            {
                new Argument("Input", "C:\\source"), 
                new Argument("Output", "C:\\Destination"),
                new Argument("Filter", ""),
                new Argument("OperationType", "Move")
            };

            // Act
            IFilter filter = new Filter(arguments);

            Assert.NotNull(filter);
            Assert.Null(filter.Types);
        }
    }
}
