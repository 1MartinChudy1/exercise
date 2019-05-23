using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Main.Tests
{
    [TestClass]
    public class InputReaderTest
    {
        [TestMethod]
        [DataRow("C:\\Source", "C:\\Destination", "doc,exe", "Copy")]
        [DataRow("C:\\Source", "C:\\Destination", "", "Search")]
        public void InputReader_ShouldWorkCorrectly(string source = null, string destination = null,
            string filter = null, string operation = null)
        {
            // Arrange
            string[] args = new[] {source, destination, filter, operation};

            // Act
            IInput reader = new InputReader();
            IEnumerable<Argument> arguments = reader.Read(args);

            // Assert
            Assert.IsNotNull(arguments);

            Assert.AreEqual(arguments.ElementAt(0).Name, "Input");
            Assert.AreEqual(arguments.ElementAt(0).Value, source);
            
            Assert.AreEqual(arguments.ElementAt(1).Name, "Output");
            Assert.AreEqual(arguments.ElementAt(1).Value, destination);
            
            Assert.AreEqual(arguments.ElementAt(2).Name, "Filter");
            Assert.AreEqual(arguments.ElementAt(2).Value, filter);

            Assert.AreEqual(arguments.ElementAt(3).Name, "OperationType");
            Assert.AreEqual(arguments.ElementAt(3).Value, operation);
        }
        
        [TestMethod]
        [DataRow(new string[]{"C:\\Source", "C:\\Destination", "Copy"})]
        [DataRow(new string[]{"C:\\Source", "Search"})]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InputReader_ShouldThrowArgumentOutOfRangeException(string[] args)
        {
            // Act
            InputReader reader = new InputReader();
            var test = reader.Read(args);

            // Assert
            Assert.AreEqual(test.ElementAt(0).Name, "Input");
        }

        [TestMethod]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InputReader_ShouldThrowArgumentNullException(string[] args)
        {
            // Act
            InputReader reader = new InputReader();
            var test = reader.Read(args);

            // Assert
            Assert.AreEqual(test.ElementAt(0).Name, "Input");
        }
    }
}