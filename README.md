Fakes.Contrib
=============
This library is a contribution to Microsoft Fakes. It allows to verify expectations on mocks with an easy and fluent syntax.

Installation
------------
To install Fakes.Contrib, run the following command in the Package Manager Console

	PM> Install-Package Fakes.Contrib

Usage
-----
**Note**: each scenarios use a stub generated from the interface bellow and using the Microsoft Fakes tooling.

	public interface IMyComponent
	{
		void MyMethod();
		
		void MyMethod(MyClass obj);
		void MyMethodOnMultiple(IEnumerable<MyClass> items);
		
		void MyOtherMethod(MyOtherClass obj);
		void MyOtherMethodOnMultiple(IEnumerable<MyOtherClass> items);
	}

**Scenario 1**: we want to verify that our SUT calls `MyMethod()` on the injected component.
	
	// Arrange
	var stub = new StubIMyComponent().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething();
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod());

**Scenario 2**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes the reference to the object that it received.

	// Arrange
	var obj = new MyClass();
	var stub = new StubIMyComponent().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(obj));

**Scenario 3**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes any instance of the object's type.

	// Arrange
	var obj = new MyClass();
	var stub = new StubIMyComponent().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(With.Any<MyClass>()));

**Scenario 4**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes an instance that matches (using a predicate) the instance it received.

	// Arrange
	var obj = new MyClass { MyProperty = "Hello world !" };
	var stub = new StubIMyComponent().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(
		With<MyClass>.Like(x => x.MyProperty.Contains("world"))));

**Scenario 5**: we want to verify that our SUT calls `MyOtherMethod()` on the injected component and passes an instance of a different type that matches (using a predicate) the instance it received.

	// Arrange
	var obj = new MyClass { MyProperty = "Hello world !" };
	var stub = new StubIMyComponent().WithObserver();
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
	var stub = new StubIMyComponent().WithObserver();
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
	var stub = new StubIMyComponent().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomehtingDifferentOnMultiple(array);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyOtherMethodOnMultiple(
		With.Enumerable(array)
			.Like<MyOtherClass>((source, item) => source.MyProperty == item.MyProperty)));

Release notes
-------------
* Version 0.4: improved `With` to allow predicate of two different types
* Version 0.3: added more flexible ways to verify a mock
* Version 0.2: first usable version. Watch out, this is still apha code !

About the author
------
[Fabian Vilers](http://be.linkedin.com/in/fvilers)  
Twitter: [@fvilers](http://www.twitter.com/fvilers)
