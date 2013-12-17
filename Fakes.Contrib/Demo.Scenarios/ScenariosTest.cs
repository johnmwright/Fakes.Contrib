using Demo.Fakes;
using Fakes.Contrib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Fakes;
using System.Net.Http;
using System.Net.Http.Fakes;
using System.Threading.Tasks;

namespace Demo.Scenarios
{
    [TestClass]
    public class ScenariosTest
    {
        [TestMethod]
        public void Scenario01()
        {
            // Arrange
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething();

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod());
        }

        [TestMethod]
        public void Scenario02()
        {
            // Arrange
            var obj = new MyClass();
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod(obj));
        }

        [TestMethod]
        public void Scenario03()
        {
            // Arrange
            var obj = new MyClass();
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod(With.Any<MyClass>()));
        }

        [TestMethod]
        public void Scenario04()
        {
            // Arrange
            var obj = new MyClass { MyProperty = "Hello world !" };
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomething(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethod(With<MyClass>.Like(x => x.MyProperty.Contains("world"))));
        }

        [TestMethod]
        public void Scenario05()
        {
            // Arrange
            var obj = new MyClass { MyProperty = "Hello world !" };
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomethingDifferent(obj);

            // Assert
            stub.AssertWasCalled(mock => mock.MyOtherMethod(With<MyOtherClass>.Like(other => other.MyProperty == obj.MyProperty)));
        }

        [TestMethod]
        public void Scenario06()
        {
            // Arrange
            var array = new[]
            {
                new MyClass {MyProperty = "Value 1"},
                new MyClass {MyProperty = "Value 2"}
            };
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomehtingOnMultiple(array);

            // Assert
            stub.AssertWasCalled(mock => mock.MyMethodOnMultiple(With.Enumerable(array).Like<MyClass>((source, item) => source == item)));
        }

        [TestMethod]
        public void Scenario07()
        {
            // Arrange
            var array = new[]
            {
                new MyClass {MyProperty = "Value 1"},
                new MyClass {MyProperty = "Value 2"}
            };
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomehtingDifferentOnMultiple(array);

            // Assert
            stub.AssertWasCalled(mock => mock.MyOtherMethodOnMultiple(With.Enumerable(array).Like<MyOtherClass>((source, item) => source.MyProperty == item.MyProperty)));
        }

        [TestMethod]
        public void Scenario08()
        {
            // Arrange
            var array = new MyClass[0];
            var stub = new StubIMyComponent().AsObservable();
            var sut = MakeSut(stub);

            // Act
            sut.DoSomehtingDifferentOnMultiple(array);

            // Assert
            stub.AssertWasNotCalled(mock => mock.MyOtherMethodOnMultiple(With.Enumerable(array).Like<MyOtherClass>((source, item) => source.MyProperty == item.MyProperty)));
        }

        [TestMethod]
        public void Scenario09()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var now = new DateTime(2013, 1, 1);
                ShimDateTime.NowGet = () => now;
                var sut = MakeSut();

                // Act
                sut.ReturnDateTimeNow();

                // Assert
                context.AssertWasCalled(() => DateTime.Now);
            }
        }

        [TestMethod]
        public void Scenario10()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                ShimGuid.NewGuid = () => new Guid("97f31de6-5a03-454a-976f-76e2a54a89d4");
                var sut = MakeSut();

                // Act
                sut.ReturnNewGuid();

                // Assert
                context.AssertWasCalled(() => Guid.NewGuid());
            }
        }

        [TestMethod]
        public async Task Scenario11()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                const string url = "http://www.dev-one.com";
                var sut = MakeSut();
                ShimHttpClient.AllInstances.GetStringAsyncString = (c, u) => Task.FromResult("ok");

                // Act
                await sut.GoOnTheWeb(url);

                // Assert (ATM, parameter cannot be verified)
                context.AssertWasCalled((HttpClient client) => client.GetStringAsync(url));
            }
        }

        private static IMyService MakeSut(IMyComponent component = null)
        {
            component = component ?? new StubIMyComponent();

            var sut = new MyService(component);

            return sut;
        }
    }
}
