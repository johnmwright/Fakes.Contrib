using Demo.Fakes;
using Fakes.Contrib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Scenarios
{
    [TestClass]
    public class ScenariosTest
    {
        [TestMethod]
        public void Scenario1()
        {
            // Arrange
            var stub = new StubIMyComponent().WithObserver();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething();

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod());
        }

        [TestMethod]
        public void Scenario2()
        {
            // Arrange
            var obj = new MyClass();
            var stub = new StubIMyComponent().WithObserver();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod(obj));
        }

        [TestMethod]
        public void Scenario3()
        {
            // Arrange
            var obj = new MyClass();
            var stub = new StubIMyComponent().WithObserver();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod(With.Any<MyClass>()));
        }

        [TestMethod]
        public void Scenario4()
        {
            // Arrange
            var obj = new MyClass { MyProperty = "Hello world !" };
            var stub = new StubIMyComponent().WithObserver();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod(With<MyClass>.Like(x => x.MyProperty.Contains("world"))));
        }

        [TestMethod]
        public void Scenario5()
        {
            // Arrange
            var obj = new MyClass { MyProperty = "Hello world !" };
            var stub = new StubIMyComponent().WithObserver();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomethingDifferent(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyOtherMethod(With<MyOtherClass>.Like(other => other.MyProperty == obj.MyProperty)));
        }

        [TestMethod]
        public void Scenario6()
        {
            // Arrange
            var array = new[]
            {
                new MyClass {MyProperty = "Value 1"},
                new MyClass {MyProperty = "Value 2"}
            };
            var stub = new StubIMyComponent().WithObserver();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomehtingOnMultiple(array);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethodOnMultiple(With.Enumerable(array).Like<MyClass>((source, item) => source == item)));
        }

        [TestMethod]
        public void Scenario7()
        {
            // Arrange
            var array = new[]
            {
                new MyClass {MyProperty = "Value 1"},
                new MyClass {MyProperty = "Value 2"}
            };
            var stub = new StubIMyComponent().WithObserver();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomehtingDifferentOnMultiple(array);

            // Assert
            stub.AssertWasCalled(mock => mock.MyOtherMethodOnMultiple(With.Enumerable(array).Like<MyOtherClass>((source, item) => source.MyProperty == item.MyProperty)));
        }

        private static IMyService MakeSut(IMyComponent component = null)
        {
            component = component ?? new StubIMyComponent();

            var sut = new MyService(component);

            return sut;
        }
    }
}
