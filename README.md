Fakes.Contrib
=============
This library is a contribution to Microsoft Fakes.

Installation
------------
To install Fakes.Contrib, run the following command in the Package Manager Console

```
PM> Install-Package Fakes.Contrib
```

Usage
-----
**Scenario 1**: we want to verify that our SUT calls `MyMethod()` on the injected component.
	
	// Arrange
	var stub = new Stub().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething();
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod());

**Scenario 2**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes the reference to the object that it received.

	// Arrange
	var obj = new object();
	var stub = new Stub().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(obj));

**Scenario 3**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes any instance of the object's type.

	// Arrange
	var obj = new object();
	var stub = new Stub().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(obj);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(With.Any<object>()));

**Scenario 4**: we want to verify that our SUT calls `MyMethod()` on the injected component and passes an instance that matches (using a predicate) the instance it received.

	// Arrange
	var str = "my string";
	var stub = new Stub().WithObserver();
	var sut = MakeSut(stub);
	
	// Act
	sut.DoSomething(str);
	
	// Assert
	stub.AssertWasCalled(mock => mock.MyMethod(With<string>.Like(s => s.Contains("my"))));

**More scenario to come...**

Release notes
-------------
* Version 0.4: improved `With` to allow predicate of two different types
* Version 0.3: added more flexible ways to verify a mock
* Version 0.2: first usable version. Watch out, this is still apha code !

About the author
------
Fabian Vilers  
Twitter: [@fvilers](http://www.twitter.com/fvilers)
