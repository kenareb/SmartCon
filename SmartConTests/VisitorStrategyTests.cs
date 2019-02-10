namespace SmartConTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SmartCon;
    using System.Collections.Generic;

    [TestClass]
    public class VisitorStrategyTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var visitor = new VisitorStrategy();
            var myMock1 = new Mock<ArgumentHandler>();
            var myMock2 = new Mock<ArgumentHandler>();

            var dict = new Dictionary<string, ArgumentHandler>();
            dict["1"] = myMock1.Object;
            dict["2"] = myMock2.Object;

            // Act
            visitor.Process(new[] { "package1", "package2", "package3" }, CommandLineDescription.DefaultCommandLine, dict);

            // Verify
            myMock1.Verify(x => x("package1"), Times.Once);
            myMock1.Verify(x => x("package2"), Times.Once);
            myMock1.Verify(x => x("package3"), Times.Once);

            myMock2.Verify(x => x("package1"), Times.Once);
            myMock2.Verify(x => x("package2"), Times.Once);
            myMock2.Verify(x => x("package3"), Times.Once);
        }
    }
}