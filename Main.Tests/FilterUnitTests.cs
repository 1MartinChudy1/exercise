using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Main.Tests
{
    [TestClass]
    public class FilterUnitTests
    {
        [TestMethod]
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
            Assert.IsNotNull(filter);
            Assert.IsNotNull(filter.Types);
            for (int i = 0; i < filter.Types.Count() - 1; i++)
            {
                Assert.AreEqual(filter.Types.ElementAt(i), filterArgument.ElementAt(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Filter_ShouldThrowArgumentNullException()
        {
            // Arrange
            IEnumerable<Argument> arguments = null;

            // Act & Assert
            IFilter filter = new Filter(arguments);
        }

        [TestMethod]
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

            Assert.IsNotNull(filter);
            Assert.IsNull(filter.Types);
        }
    }
}
