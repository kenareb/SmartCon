using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartCon;
using System;

namespace SmartConTests
{
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

        private ArgumentHandleResult DummySuccessHandler(string value)
        {
            _successHandlerInvoked = true;
            return ArgumentHandleResult.Handled;
        }

        private bool _failedHandlerInvoked = false;

        private ArgumentHandleResult DummyFailedHandler(string value)
        {
            _failedHandlerInvoked = true;
            return ArgumentHandleResult.Failed;
        }

        private bool _postprocessHandlerInvoked = false;

        private ArgumentHandleResult DummyPostpocessHandler()
        {
            _postprocessHandlerInvoked = true;
            return ArgumentHandleResult.Handled;
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
            var unitUnderTest = this.CreateArgumentProcessor();
            string key = "h";
            ProcessHandler handler = DummyPostpocessHandler;
            _successHandlerInvoked = false;

            // Act
            unitUnderTest.RegisterPostProcessor(handler);

            unitUnderTest.Process(new[] { "-h" });

            // Assert
            Assert.IsTrue(_postprocessHandlerInvoked);
        }
    }
}