namespace SmartConTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SmartCon;
    using System;

    [TestClass]
    public class TextIndentTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private TextIndent CreateTextIndent()
        {
            return new TextIndent();
        }

        private TextIndent CreateTextIndent(string prefix, int level)
        {
            var options = new SmartConsoleOptions();
            options.IndentationText = prefix;
            while (options.IndentationLevel < level)
            {
                options.IncreaseIndent();
            }
            return new TextIndent(options);
        }

        [TestMethod]
        public void IndentInput_Must_Prefix_With_Default()
        {
            // Arrange
            var unitUnderTest = TextIndent.DefaultIndent;

            var input = "Sample line";
            var expected01 = "Sample line";
            var expected02 = "    Sample line";

            // Act
            var result01 = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected01, result01);

            unitUnderTest.IncreaseIndentationLevel();

            // Act
            var result02 = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected02, result02);
        }

        [TestMethod]
        public void IndentInput_Must_Prefix_With_Space()
        {
            // Arrange
            var unitUnderTest = this.CreateTextIndent("  ", 1);

            string input = "Sample line";
            string expected = "  Sample line";

            // Act
            var result = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IndentInput_Must_Prefix_With_Dots()
        {
            // Arrange
            var unitUnderTest = this.CreateTextIndent("..", 1);

            string input = "Sample line";
            string expected = "..Sample line";

            // Act
            var result = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IndentInput_Must_Prefix_With_Multiple_Lines()
        {
            // Arrange
            var unitUnderTest = this.CreateTextIndent("..", 1);

            string input = "Sample line\r\nSecond line";
            string expected = "..Sample line\r\n..Second line";

            // Act
            var result = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IndentInput_Must_Prefix_With_Different_Levels()
        {
            // Arrange
            var unitUnderTest = this.CreateTextIndent("..", 1);

            string input = "Sample line";
            string expected1 = "..Sample line";
            string expected2 = "....Sample line";

            // Act
            var result1 = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected1, result1);

            unitUnderTest.IncreaseIndentationLevel();

            // Act
            var result2 = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected2, result2);

            unitUnderTest.DecreaseIndentationLevel();

            // Act
            var result3 = unitUnderTest.IndentInput(input);

            // Assert
            Assert.AreEqual(expected1, result3);
        }
    }
}