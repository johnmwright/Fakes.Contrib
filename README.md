Fakes.Contrib
=============
This library is a contribution to Microsoft Fakes. It allows tests to verify expectations on mocks with an easy and fluent syntax.

Installation
------------
To install Fakes.Contrib, run the following command in the Package Manager Console

	PM> Install-Package Fakes.Contrib

Usage
-----
**Note**: each scenarios use a stub generated from the interface below and using the Microsoft Fakes tooling.

	public interface IMyComponent
	{
		void MyMethod();
		
		void MyMethod(MyClass obj);
		void MyMethodOnMultiple(IEnumerable<MyClass> items);
		
		void MyOtherMethod(MyOtherClass obj);
		void MyOtherMethodOnMultiple(IEnumerable<MyOtherClass> items);
		void MyMethodUsingAnInterface(IMyOtherInterface obj);
	}

**Scenario 1**: we want to verify that our SUT calls `MyMethod()` on the injected component.
	
	// Arrange
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething();
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod());

**Scenario 2**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes the reference to the object that it received.

	// Arrange
	var obj = new MyClass();
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(obj));

**Scenario 3**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes any instance of the object's type.

	// Arrange
	var obj = new MyClass();
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(With.Any<MyClass>()));

**Scenario 4**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes an instance that matches (using a predicate) the instance it received.

	// Arrange
	var obj = new MyClass { MyProperty = "Hello world !" };
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(
		With<MyClass>.Like(x => x.MyProperty.Contains("world"))));

**Scenario 5**: we want to verify that our SUT calls `MyOtherMethod()` on the injected component and passes an instance of a different type that matches (using a predicate) the instance it received.

	// Arrange
	var obj = new MyClass { MyProperty = "Hello world !" };
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomethingDifferent(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyOtherMethod(
		With<MyOtherClass>.Like(other => other.MyProperty == obj.MyProperty)));

**Scenario 6**: we want to verity that our SUT calls `MyMethodOnMultiple()` on the injected component and passes an IEnumerable of the references to the object that it received.

	// Arrange
	var array = new[]
	{
		new MyClass { MyProperty = "Value 1" },
		new MyClass { MyProperty = "Value 2" }
	};
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomehtingOnMultiple(array);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethodOnMultiple(
		With.Enumerable(array).Like<MyClass>((source, item) => source == item)));

**Scenario 7**: we want to verity that our SUT calls `MyOtherMethodOnMultiple()` on the injected component and passes an IEnumerable of different type that match (using a predicate) the IEnumerable it received.

	// Arrange
	var array = new[]
	{
		new MyClass { MyProperty = "Value 1" },
		new MyClass { MyProperty = "Value 2" }
	};
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomehtingDifferentOnMultiple(array);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyOtherMethodOnMultiple(
		With.Enumerable(array)
			.Like<MyOtherClass>((source, item) => source.MyProperty == item.MyProperty)));

**Scenario 8**: we want to verify that our SUT does not call `MyOtherMethodOnMultiple()` on the injected component.

	// Arrange
	var array = new MyClass[0];
	var stub = new StubIMyComponent().AsObservable();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomehtingDifferentOnMultiple(array);
	
	// Assert
	stub.AssertWasNotCalled(mock => mock.MyOtherMethodOnMultiple(
		With.Enumerable(array)
			.Like<MyOtherClass>((source, item) => source.MyProperty == item.MyProperty)));

**Scenario 9**: we want to verify that our SUT does call a static property on a .NET component that was shimed.

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

**Scenario 10**: we want to verify that our SUT does call a static method on a .NET component that was shimed.

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

**Scenario 11**: we want to verify that our SUT does call a method on an instantiated .NET component that was shimed. Note that with the current implementation of the shims' detour, the parameter cannot be verified.

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

Release notes
-------------
* Version 0.7: 
  * added support for interface types
  * removed assembly signing
  * updated copyright and maintainer/owner information
* Version 0.6: added an `ObservableShimsContext` to allow verifications on shims
* Version 0.5: added an `AssertWasNotCalled` assertion
* Version 0.4: improved `With` to allow predicate of two different types
* Version 0.3: added more flexible ways to verify a mock
* Version 0.2: first usable version. Watch out, this is still apha code !

About the authors
------

This package is maintained by [John M. Wright](https://wrightfully.com) [ Twitter: [@Wright2Tweet](twitter.com/intent/follow?screen_name=Wright2Tweet) ]


Fakes.Contrib was originally written and maintained by [Fabian Vilers](http://be.linkedin.com/in/fvilers) and [Dev One](https://www.dev-one.com/). [ Twitter: [@fvilers](twitter.com/intent/follow?screen_name=fvilers) ]
