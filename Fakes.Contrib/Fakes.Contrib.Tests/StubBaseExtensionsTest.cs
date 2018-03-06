using Microsoft.QualityTools.Testing.Fakes.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Fakes.Contrib.Tests
{
    [TestClass]
    public class StubBaseExtensionsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WithObserverShouldThrowAnExceptionForNullStub()
        {
            // Arrange
            IStubObservable stub = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            stub.AsObservable();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WithObserverShouldThrownAnExceptionIfTheStubHasAnIncompatibleObserver()
        {
            // Arrange
            var stub = new Mock<IStubObservable>();
            stub.SetupGet(mock => mock.InstanceObserver).Returns(new Mock<IStubObserver>().Object);

            // Act
            stub.Object.AsObservable();
        }

        [TestMethod]
        public void WithObserverShouldLeaveTheCurrentObserverIfCompatible()
        {
            // Arrange
            var observer = new StubObserver();
            var stub = new Mock<IStubObservable>();
            stub.SetupGet(mock => mock.InstanceObserver).Returns(observer);

            // Act
            stub.Object.AsObservable();

             // Assert
            stub.VerifySet(mock => mock.InstanceObserver = observer, Times.Never);
        }

        [TestMethod]
        public void WithObserverShouldSetTheObserverIfCurrnetObserverIsNull()
        {
            // Arrange
            var stub = new Mock<IStubObservable>();
            stub.SetupGet(mock => mock.InstanceObserver).Returns((IStubObserver)null);
            stub.SetupSet(mock => mock.InstanceObserver = It.IsAny<IStubObserver>());

            // Act
            stub.Object.AsObservable();

             // Assert
            stub.VerifySet(mock => mock.InstanceObserver = It.IsAny<StubObserver>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertWasCalledShouldThrowAnExceptionForNullStub()
        {
            // Arrange
            StubBase<object> stub = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            stub.AssertWasCalled(mock => mock.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssertWasCalledShouldThrowAnExceptionForNullInstanceObserver()
        {
            // Arrange
            var stub = new TestStub();

            // Act
            stub.AssertWasCalled(mock => mock.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssertWasCalledShouldThrowAnExceptionForInstanceObserverNotAStubObserver()
        {
            // Arrange
            var stub = new TestStub
            {
                InstanceObserver = new Mock<IStubObserver>().Object
            };

            // Act
            stub.AssertWasCalled(mock => mock.ToString());
        }

        private class TestStub : StubBase<object>
        {
        }
    }
}
