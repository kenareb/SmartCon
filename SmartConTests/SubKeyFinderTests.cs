namespace SmartConTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SmartCon;
    using System.Collections.Generic;

    [TestClass]
    public class SubKeyFinderTests
    {
        private MockRepository mockRepository;
        private Mock<ArgumentHandler> mockHelp;
        private Mock<ArgumentHandler> mockHelpCollision;
        private Mock<ArgumentHandler> mockFile;
        private Mock<ArgumentHandler> mockFileCollision;
        private Mock<ArgumentHandler> mockOutput;
        private IDictionary<string, ArgumentHandler> mockDictionary;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Loose);
            mockHelp = mockRepository.Create<ArgumentHandler>();
            mockHelpCollision = mockRepository.Create<ArgumentHandler>();
            mockFile = mockRepository.Create<ArgumentHandler>();
            mockFileCollision = mockRepository.Create<ArgumentHandler>();
            mockOutput = mockRepository.Create<ArgumentHandler>();
        }

        private void SetupDictWithoutCollision()
        {
            mockDictionary = new Dictionary<string, ArgumentHandler>();
            mockDictionary["help"] = mockHelp.Object;
            mockDictionary["file"] = mockFile.Object;
            mockDictionary["output"] = mockOutput.Object;
        }

        private void SetupDictWithCollision()
        {
            mockDictionary = new Dictionary<string, ArgumentHandler>();
            mockDictionary["help"] = mockHelp.Object;
            mockDictionary["hight"] = mockHelpCollision.Object;
            mockDictionary["file"] = mockFile.Object;
            mockDictionary["filter"] = mockFileCollision.Object;
            mockDictionary["output"] = mockOutput.Object;
        }

        private SubKeyFinder CreateSubKeyFinderCS()
        {
            return new SubKeyFinder(mockDictionary, true);
        }

        private SubKeyFinder CreateSubKeyFinderCI()
        {
            return new SubKeyFinder(mockDictionary, false);
        }

        [TestMethod]
        public void Must_Find_Help_For_H()
        {
            // Arrange
            SetupDictWithoutCollision();
            var unitUnderTest = CreateSubKeyFinderCS();

            // Act
            var actual = unitUnderTest.Find("h");

            // Assert
            Assert.AreEqual(mockHelp.Object, actual);
        }

        [TestMethod]
        public void Must_Not_Find_Help_For_H()
        {
            // Arrange
            SetupDictWithCollision();
            var unitUnderTest = CreateSubKeyFinderCS();

            // Act
            var actual = unitUnderTest.Find("h");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Must_Find_Help_For_HELP()
        {
            // Arrange
            SetupDictWithoutCollision();
            var unitUnderTest = CreateSubKeyFinderCI();

            // Act
            var actual01 = unitUnderTest.Find("HELP");
            var actual02 = unitUnderTest.Find("H");

            // Assert
            Assert.AreEqual(mockHelp.Object, actual01);
            Assert.AreEqual(mockHelp.Object, actual02);
        }
    }
}