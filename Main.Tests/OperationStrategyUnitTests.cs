using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Main.Tests
{
    [TestClass]
    public class OperationStrategyUnitTests
    {
        [TestMethod]
        public void OperationStrategy_ShouldSelectCopyType()
        {
            // Arrange
            IEnumerable<IFile> files = new List<IFile>();
            IEnumerable<Argument> arguments= new List<Argument>
            {
                new Argument("Input", "C:\\Source"),
                new Argument("Output", "C:\\Destination"),
                new Argument("Filter", ""),
                new Argument("OperationType", "Copy")
            };
            IFilter filter = new Filter(arguments);


            // Act
            OperationStrategy operationStrategy = new OperationStrategy(files, filter);
            IType type = operationStrategy.PickMeasurementType(arguments);

            // Assert
            Assert.IsTrue(type.GetType() == typeof(CopyType));
        }

        [TestMethod]
        public void OperationStrategy_ShouldSelectMoveType()
        {
            // Arrange
            IEnumerable<IFile> files = new List<IFile>();
            IEnumerable<Argument> arguments= new List<Argument>
            {
                new Argument("Input", "C:\\Source"),
                new Argument("Output", "C:\\Destination"),
                new Argument("Filter", ""),
                new Argument("OperationType", "Move")
            };
            IFilter filter = new Filter(arguments);


            // Act
            OperationStrategy operationStrategy = new OperationStrategy(files, filter);
            IType type = operationStrategy.PickMeasurementType(arguments);

            // Assert
            Assert.IsTrue(type.GetType() == typeof(MoveType));
        }

        [TestMethod]
        public void OperationStrategy_ShouldSelectSearchType()
        {
            // Arrange
            IEnumerable<IFile> files = new List<IFile>();
            IEnumerable<Argument> arguments= new List<Argument>
            {
                new Argument("Input", "C:\\Source"),
                new Argument("Output", "C:\\Destination"),
                new Argument("Filter", ""),
                new Argument("OperationType", "Search")
            };
            IFilter filter = new Filter(arguments);

            // Act
            OperationStrategy operationStrategy = new OperationStrategy(files, filter);
            IType type = operationStrategy.PickMeasurementType(arguments);

            // Assert
            Assert.IsTrue(type.GetType() == typeof(SearchType));
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void OperationStrategy_ShouldThrowValidationException()
        {
            // Arrange
            IEnumerable<IFile> files = new List<IFile>();
            IEnumerable<Argument> arguments= new List<Argument>
            {
                new Argument("Input", "C:\\Source"),
                new Argument("Output", "C:\\Destination"),
                new Argument("Filter", ""),
                new Argument("OperationType", "")
            };
            IFilter filter = new Filter(arguments);

            // Act & Assert
            OperationStrategy operationStrategy = new OperationStrategy(files, filter);
            IType type = operationStrategy.PickMeasurementType(arguments);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void OperationStrategy_ShouldThrowNullReferenceException()
        {
            // Arrange
            IEnumerable<IFile> files = null;
            IEnumerable<Argument> arguments= new List<Argument>
            {
                new Argument("Input", "C:\\Source"),
                new Argument("Output", "C:\\Destination"),
                new Argument("Filter", ""),
                new Argument("OperationType", "")
            };
            IFilter filter = null;

            // Act & Assert
            OperationStrategy operationStrategy = new OperationStrategy(files, filter);
            IType type = operationStrategy.PickMeasurementType(arguments);
        }
    }
}
