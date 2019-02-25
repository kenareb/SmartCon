namespace SmartConTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SmartCon;
    using System;
    using System.Linq;

    [TestClass]
    public class CommandProcessorTests
    {
        [TestMethod]
        public void RegisteredCommand_Must_Call_Command_With_Args()
        {
            // Arrange:
            var processor = new CommandProcessor();
            var commandName = "install";
            var myMock = new Mock<IArgumentProcessor>();
            processor.RegisterCommand(
                commandName,
                myMock.Object);

            // Act:
            processor.Process(new[] { "install", "package1", "package2", "pacakge3" });

            // Verify:
            myMock.Verify(x => x.Process(new[] { "package1", "package2", "pacakge3" }), Times.Once);
        }

        [TestMethod]
        public void RegisteredCommand_Must_Not_Call_Command()
        {
            // Arrange:
            var processor = new CommandProcessor();
            var commandName = "adduser";
            var myMock = new Mock<IArgumentProcessor>();
            processor.RegisterCommand(
                commandName,
                myMock.Object);

            // Act:
            processor.Process(new[] { "install", "package1", "package2", "pacakge3" });

            // Verify:
            myMock.Verify(x => x.Process(new[] { "package1", "package2", "pacakge3" }), Times.Never);
        }
    }
}