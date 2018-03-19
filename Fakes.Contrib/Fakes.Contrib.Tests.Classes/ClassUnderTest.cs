using System;
using System.Collections.Generic;
using System.IO;

namespace Fakes.Contrib.Tests.Classes
{
    
        public class ClassUnderTest
        {
            public void TestMethod_ArrayOfLongs(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesArray(new long[] { long.MinValue, 0, 1, 2, 3, long.MaxValue });
            }

            public void TestMethod_LongParams(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesParams(long.MinValue, 1, 2, 3, long.MaxValue);
            }


            public void TestMethod_ArrayOfLongs(IMethodsThatTakeArrays dependancy, long[] inputs)
            {
                dependancy.MethodTakesArray(inputs);
            }

            public void TestMethod_ArrayOfInt(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesArray(new int[] { int.MinValue, 0, 1, 2, 3, int.MaxValue });
            }

            public void TestMethod_IntParams(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesParams(int.MinValue, 1, 2, 3, int.MaxValue);
            }


            public void TestMethod_ArrayOfInt(IMethodsThatTakeArrays dependancy, int[] inputs)
            {
                dependancy.MethodTakesArray(inputs);
            }

            public void TestMethod_ArrayOfString(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesArray(new string[] { "", "foo", "bar", "baz", "bin" });
            }

            public void TestMethod_StringParams(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesParams("", "foo", "bar", "baz", "bin");
            }


            public void TestMethod_ArrayOfString(IMethodsThatTakeArrays dependancy, string[] inputs)
            {
                dependancy.MethodTakesArray(inputs);
            }

            public void TestMethod_ArrayOfObject(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesArray<object>(new object[] { new object(), "bin", new ClassUnderTest() });
            }

            public void TestMethod_ObjectParams(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesParams<object>(new object(), "bin", new ClassUnderTest());
            }


            public void TestMethod_ArrayOfObject(IMethodsThatTakeArrays dependancy, object[] inputs)
            {
                dependancy.MethodTakesArray(inputs);
            }

            public void TestMethod_ArrayOfInterface(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesArray(new IDisposable[] { new StreamReader(Stream.Null), new MemoryStream() });
            }

            public void TestMethod_InterfaceParams(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesParams<IDisposable>(new StreamReader(Stream.Null), new MemoryStream());
            }


            public void TestMethod_ArrayOfInterface(IMethodsThatTakeArrays dependancy, IDisposable[] inputs)
            {
                dependancy.MethodTakesArray(inputs);
            }

            public void TestMethod_ArrayOfGeneric(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesArray(new List<int>[] { new List<int>() { 0, 1 }, new List<int>() { 3, 4 } });
            }

            public void TestMethod_GenericParams(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesParams(new List<int>() { 0, 1 }, new List<int>() { 3, 4 });
            }


            public void TestMethod_ArrayOfGeneric(IMethodsThatTakeArrays dependancy, List<int>[] inputs)
            {
                dependancy.MethodTakesArray(inputs);
            }

            public void TestMethod_ArrayOfDates(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesArray(new DateTime[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now });
            }

            public void TestMethod_DateParams(IMethodsThatTakeArrays dependancy)
            {
                dependancy.MethodTakesParams(DateTime.MinValue, DateTime.MaxValue, DateTime.Now);
            }


            public void TestMethod_ArrayOfDates(IMethodsThatTakeArrays dependancy, DateTime[] inputs)
            {
                dependancy.MethodTakesArray(inputs);
            }
        }
       
   
}
