using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Main.Tests
{
    public class OperationStrategyUnitTests
    {
        [Fact]
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
            Assert.True(type.GetType() == typeof(CopyType));
        }

        [Fact]
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
            Assert.True(type.GetType() == typeof(MoveType));
        }

        [Fact]
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
            Assert.True(type.GetType() == typeof(SearchType));
        }

        [Fact]
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
            Action act = () => operationStrategy.PickMeasurementType(arguments);

            // Assert
            Assert.Throws<ValidationException>(act);
        }

        [Fact]
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
            Action act = () => new OperationStrategy(files, filter);

            // Assert
            Assert.Throws<NullReferenceException>(act);
        }
    }
}
