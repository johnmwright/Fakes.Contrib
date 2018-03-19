using System;
using System.Collections.Generic;
using System.IO;
using Fakes.Contrib.Tests.Classes;
using Fakes.Contrib.Tests.Classes.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fakes.Contrib.Tests
{
    [TestClass]
    public  class TypeTestsForClassStubs
    {
        
        [TestMethod]
        public void ArrayOfLongsTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ArrayOfLongs(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(With.Any<long[]>()));
        }

        [TestMethod]
        public void ParamsOfLongTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_LongParams(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesParams(With.Any<long[]>()));
        }


        [TestMethod]
        public void ArrayOfLongExactTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            var inputs = new long[] {long.MinValue, 0, 1, 2, 3, long.MaxValue};

            // Act
            cut.TestMethod_ArrayOfLongs(stubObj, inputs);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(inputs));
        }

        [TestMethod]
        public void ArrayOfIntsTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ArrayOfInt(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(With.Any<int[]>()));
        }

        [TestMethod]
        public void ParamsOfIntTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_IntParams(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesParams(With.Any<int[]>()));
        }


        [TestMethod]
        public void ArrayOfIntsExactTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            var inputs = new int[] {int.MinValue, 0, 1, 2, 3, int.MaxValue};

            // Act
            cut.TestMethod_ArrayOfInt(stubObj, inputs);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(inputs));
        }

        [TestMethod]
        public void ArrayOfStringTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ArrayOfString(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(With.Any<string[]>()));
        }

        [TestMethod]
        public void ParamsOfStringTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_StringParams(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesParams(With.Any<string[]>()));
        }


        [TestMethod]
        public void ArrayOfStringExactTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            var inputs = new string[] {"", "foo", "bar", "baz", "bin"};

            // Act
            cut.TestMethod_ArrayOfString(stubObj, inputs);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(inputs));
        }

        [TestMethod]
        public void ArrayOfObjectTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ArrayOfObject(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(With.Any<object[]>()));
        }

        [TestMethod]
        public void ParamsOfObjectTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ObjectParams(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesParams(With.Any<object[]>()));
        }

        [TestMethod]
        public void ArrayOfObjectExactTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            var inputs = new object[] {new object(), "bin", new ClassUnderTest()};

            // Act
            cut.TestMethod_ArrayOfObject(stubObj, inputs);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(inputs));
        }


        [TestMethod]
        public void ArrayOfInterfaceTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ArrayOfInterface(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(With.Any<IDisposable[]>()));
        }

        [TestMethod]
        public void ParamsOfInterfaceTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_InterfaceParams(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesParams(With.Any<IDisposable[]>()));
        }


        [TestMethod]
        public void ArrayOfInterfaceExactTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            var inputs = new IDisposable[] {new StreamReader(Stream.Null), new MemoryStream()};

            // Act
            cut.TestMethod_ArrayOfInterface(stubObj, inputs);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(inputs));
        }


        [TestMethod]
        public void ArrayOfGenericTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ArrayOfGeneric(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(With.Any<List<int>[]>()));
        }

        [TestMethod]
        public void ParamsOfGenericTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_GenericParams(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesParams(With.Any<List<int>[]>()));
        }



        [TestMethod]
        public void ArrayOfGenericExactTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            var inputs = new List<int>[] {new List<int>() {0, 1}, new List<int>() {3, 4}};

            // Act
            cut.TestMethod_ArrayOfGeneric(stubObj, inputs);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(inputs));
        }


        [TestMethod]
        public void ArrayOfDatesTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_ArrayOfDates(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(With.Any<DateTime[]>()));
        }

        [TestMethod]
        public void ParamsOfDateTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            // Act
            cut.TestMethod_DateParams(stubObj);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesParams(With.Any<DateTime[]>()));
        }


        [TestMethod]
        public void ArrayOfDateExactTest()
        {
            // Arrange
            var stubObj = new StubMethodsThatTakeArrays().AsObservable();
            var cut = new ClassUnderTest();

            var inputs =  new DateTime[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now };

            // Act
            cut.TestMethod_ArrayOfDates(stubObj, inputs);

            // Assert
            stubObj.AssertWasCalled(stub => stub.MethodTakesArray(inputs));
        }
       
    }
}
