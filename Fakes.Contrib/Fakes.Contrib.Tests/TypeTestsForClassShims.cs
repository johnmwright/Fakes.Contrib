using System;
using System.Collections.Generic;
using System.IO;
using Fakes.Contrib.Tests.Classes;
using Fakes.Contrib.Tests.Classes.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fakes.Contrib.Tests
{
    [TestClass]
    public  class TypeTestsForClassShims
    {

        [TestMethod]
        public void ArrayOfLongsTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ArrayOfLongs(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(With.Any<long[]>()));
            }
        }

        [TestMethod]
        public void ParamsOfLongTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_LongParams(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesParams(With.Any<long[]>()));
            }
        }

        [TestMethod]
        public void ArrayOfLongExactTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                var inputs = new long[] {long.MinValue, 0, 1, 2, 3, long.MaxValue};

                // Act
                cut.TestMethod_ArrayOfLongs(stubObj.Instance, inputs);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(inputs));
            }
        }

        [TestMethod]
        public void ArrayOfIntsTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ArrayOfInt(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesArray(With.Any<int[]>()));
            }
        }


        [TestMethod]
        public void ParamsOfIntTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_IntParams(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesParams(With.Any<int[]>()));
            }
        }


        [TestMethod]
        public void ArrayOfIntsExactTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                var inputs = new int[] {int.MinValue, 0, 1, 2, 3, int.MaxValue};

                // Act
                cut.TestMethod_ArrayOfInt(stubObj.Instance, inputs);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(inputs));
            }
        }

        [TestMethod]
        public void ArrayOfStringTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ArrayOfString(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesArray(With.Any<string[]>()));
            }
        }

        [TestMethod]
        public void ParamsOfStringTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_StringParams(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesParams(With.Any<string[]>()));
            }
        }


        [TestMethod]
        public void ArrayOfStringExactTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                var inputs = new string[] {"", "foo", "bar", "baz", "bin"};

                // Act
                cut.TestMethod_ArrayOfString(stubObj.Instance, inputs);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(inputs));
            }
        }

        [TestMethod]
        public void ArrayOfObjectTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ArrayOfObject(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesArray(With.Any<object[]>()));
            }
        }

        [TestMethod]
        public void ParamsOfObjectTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ObjectParams(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesParams(With.Any<object[]>()));
            }
        }

        [TestMethod]
        public void ArrayOfObjectExactTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                var inputs = new object[] {new object(), "bin", new ClassUnderTest()};

                // Act
                cut.TestMethod_ArrayOfObject(stubObj.Instance, inputs);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(inputs));
            }
        }

        [TestMethod]
        public void ArrayOfInterfaceTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ArrayOfInterface(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesArray(With.Any<IDisposable[]>()));
            }
        }

        [TestMethod]
        public void ParamsOfInterfaceTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_InterfaceParams(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesParams(With.Any<IDisposable[]>()));
            }
        }

        [TestMethod]
        public void ArrayOfInterfaceExactTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                var inputs = new IDisposable[] {new StreamReader(Stream.Null), new MemoryStream()};

                // Act
                cut.TestMethod_ArrayOfInterface(stubObj.Instance, inputs);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(inputs));
            }
        }

        [TestMethod]
        public void ArrayOfGenericTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ArrayOfGeneric(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesArray(With.Any<List<int>[]>()));
            }
        }


        [TestMethod]
        public void ParamsOfGenericTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_GenericParams(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesParams(With.Any<List<int>[]>()));
            }
        }


        [TestMethod]
        public void ArrayOfGenericExactTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                var inputs = new List<int>[] {new List<int>() {0, 1}, new List<int>() {3, 4}};

                // Act
                cut.TestMethod_ArrayOfGeneric(stubObj.Instance, inputs);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(inputs));
            }
        }

        [TestMethod]
        public void ArrayOfDatesTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_ArrayOfDates(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesArray(With.Any<DateTime[]>()));
            }
        }


        [TestMethod]
        public void ParamsOfDateTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                // Act
                cut.TestMethod_DateParams(stubObj.Instance);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) =>
                    stub.MethodTakesParams(With.Any<DateTime[]>()));
            }
        }

        [TestMethod]
        public void ArrayOfDateExactTest()
        {
            using (var context = ObservableShimsContext.Create())
            {
                // Arrange
                var stubObj = new ShimNonVirtualMethodsThatTakeArrays(){InstanceBehavior = ShimBehaviors.DefaultValue  };
                var cut = new ClassUnderTest();

                var inputs = new DateTime[] {DateTime.MinValue, DateTime.MaxValue, DateTime.Now};

                // Act
                cut.TestMethod_ArrayOfDates(stubObj.Instance, inputs);

                // Assert
                context.AssertWasCalled((NonVirtualMethodsThatTakeArrays stub) => stub.MethodTakesArray(inputs));
            }
        }

    }
}
