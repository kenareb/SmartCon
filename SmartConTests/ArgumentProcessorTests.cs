namespace SmartConTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SmartCon;
    using System;

    [TestClass]
    public class ArgumentProcessorTests
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

        private ArgumentProcessor CreateArgumentProcessor()
        {
            return new ArgumentProcessor();
        }

        private bool _successHandlerInvoked = false;

        private void DummySuccessHandler(string value)
        {
            _successHandlerInvoked = true;
        }

        private bool _failedHandlerInvoked = false;

        private void DummyFailedHandler(string value)
        {
            _failedHandlerInvoked = true;
        }

        private int _cmdHandlerCounter = 0;
        private bool _cmdHandlerInvoked = false;
        private string _cmdHandlerArg = string.Empty;

        private void DummyCmdStyleHandler(string value)
        {
            _cmdHandlerCounter++;
            _cmdHandlerArg = value;
            _cmdHandlerInvoked = true;
        }

        private bool _postprocessHandlerInvoked = false;

        private void DummyPostpocessHandler()
        {
            _postprocessHandlerInvoked = true;
        }

        [TestMethod]
        public void Processor_Must_Call_Single_Handler()
        {
            // Arrange
            _successHandlerInvoked = false;
            var unitUnderTest = this.CreateArgumentProcessor();
            string key = "h";
            ArgumentHandler handler = DummySuccessHandler;
            _successHandlerInvoked = false;

            // Act
            unitUnderTest.RegisterArgument(
                key,
                handler);

            unitUnderTest.Process(new[] { "-h" });

            // Assert
            Assert.IsTrue(_successHandlerInvoked);
        }

        [TestMethod]
        public void Processor_Must_Call_Multiple_Handler()
        {
            // Arrange
            _successHandlerInvoked = false;
            _failedHandlerInvoked = false;
            var unitUnderTest = this.CreateArgumentProcessor();
            string key1 = "h";
            ArgumentHandler handler1 = DummySuccessHandler;
            string key2 = "f";
            ArgumentHandler handler2 = DummyFailedHandler;

            // Act
            unitUnderTest.RegisterArgument(
                key1,
                handler1);

            unitUnderTest.RegisterArgument(
                key2,
                handler2);

            unitUnderTest.Process(new[] { "-h", "-f=filename" });

            // Assert
            Assert.IsTrue(_successHandlerInvoked);
            Assert.IsTrue(_failedHandlerInvoked);
        }

        [TestMethod]
        public void Processor_Must_Call_PostProcessor()
        {
            // Arrange
            _successHandlerInvoked = false;
            _successHandlerInvoked = false;
            var unitUnderTest = this.CreateArgumentProcessor();
            PostProcessHandler handler = DummyPostpocessHandler;
            unitUnderTest.RegisterPostProcessor(handler);

            // Act
            unitUnderTest.Process(new[] { "-h" });

            // Assert
            Assert.IsTrue(_postprocessHandlerInvoked);
        }

        [TestMethod]
        public void Processor_Must_Call_CmdStyle()
        {
            // Arrange
            _cmdHandlerInvoked = false;
            var unitUnderTest = this.CreateArgumentProcessor();
            unitUnderTest.CommandLineDescription = CommandLineDescription.CmdStyle;

            string key = "f";
            ArgumentHandler handler = DummyCmdStyleHandler;
            _successHandlerInvoked = false;

            _cmdHandlerCounter = 0;

            // Act
            unitUnderTest.RegisterArgument(key, handler);

            unitUnderTest.Process(new[] { "/f", "myFile" });

            // Assert
            Assert.IsTrue(_cmdHandlerInvoked);
            Assert.AreEqual(1, _cmdHandlerCounter);
            Assert.AreEqual("myFile", _cmdHandlerArg);
        }

        [TestMethod]
        public void Processor_Must_Call_CmdStyle_Without_Param()
        {
            // Arrange
            _cmdHandlerInvoked = false;
            var unitUnderTest = this.CreateArgumentProcessor();
            unitUnderTest.CommandLineDescription = CommandLineDescription.CmdStyle;

            string key = "f";
            ArgumentHandler handler = DummyCmdStyleHandler;
            _successHandlerInvoked = false;

            _cmdHandlerCounter = 0;

            // Act
            unitUnderTest.RegisterArgument(key, handler);

            unitUnderTest.Process(new[] { "/f" });

            // Assert
            Assert.IsTrue(_cmdHandlerInvoked);
            Assert.AreEqual(1, _cmdHandlerCounter);
            Assert.AreEqual("", _cmdHandlerArg);
        }
    }
}