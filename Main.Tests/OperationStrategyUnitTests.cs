using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Main.Tests
{
    public class OperationStrategyUnitTests
    {
        private static IEnumerable<Argument> arguments = new List<Argument>
        {
            new Argument("Input", "C:\\Source"),
            new Argument("Output", "C:\\Destination"),
            new Argument("Filter", ""),
            new Argument("OperationType", "")
        };


        [Fact]
        public void OperationStrategy_ShouldSelectCopyType()
        {
            // Assert
            IEnumerable<IFile> files = new List<IFile>();
            arguments.First(x => x.Name == "OperationType").Value = "Copy";
            IFilter filter = new Filter(arguments);

            // Act
            OperationStrategy operationStrategy = null;
            operationStrategy = new OperationStrategy(files, filter);
            IType type = operationStrategy.PickMeasurementType(arguments);

            // Assert
            Assert.True(type.GetType() == typeof(CopyType));
        }

        [Fact]
        public void OperationStrategy_ShouldSelectMoveType()
        {
            // Arrange
            IEnumerable<IFile> files = new List<IFile>();
            arguments.First(x => x.Name == "OperationType").Value = "Move";
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
            arguments.First(x => x.Name == "OperationType").Value = "Search";
            IFilter filter = new Filter(arguments);

            // Act
            OperationStrategy operationStrategy = new OperationStrategy(files, filter);
            IType type = operationStrategy.PickMeasurementType(arguments);

            // Assert
            Assert.True(type.GetType() == typeof(SearchType));
        }

        [Fact]
        public void OperationStrategy_ShouldThrowNullReferenceException()
        {
            // Arrange
            IEnumerable<IFile> files = null;
            arguments.First(x => x.Name == "OperationType").Value = "";
            IFilter filter = null;

            // Act & Assert
            Action act = () => new OperationStrategy(files, filter);

            // Assert
            Assert.Throws<NullReferenceException>(act);
        }
    }
}
