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
**Scenario 1**: assert that a method has been called: we want to verify that our SUT calls `MyMethod()` on the injected component.

```
// Arrange
var stub = new Stub();
var sut = MakeSut(stub);

// Act
sut.DoSomething();

// Assert
stub.AssertWasCalled(mock => mock.MyMethod());
```

**Scenario 2**: assert that a method has been called with an argument: we want to verify that our SUT calls `MyMethod()` on the injected component and passes the same object that it received.

```
// Arrange
var obj = new object();
var stub = new Stub();
var sut = MakeSut(stub);

// Act
sut.DoSomething(obj);

// Assert
stub.AssertWasCalled(mock => mock.MyMethod(obj));
```

Note that a reference equality has been performed on `obj`.

**More scenario to come...**

Release notes
-------------
* Version 0.3: added more flexible ways to verify a mock
* Version 0.2: first usable version. Watch out, this is still apha code !

About the author
------
Fabian Vilers  
Twitter: [@fvilers](http://www.twitter.com/fvilers)
