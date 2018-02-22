using System.Collections.Generic;

namespace Demo
{
    public interface IMyComponent
    {
        void MyMethod();
        void MyMethod(MyClass obj);
        void MyMethodOnMultiple(IEnumerable<MyClass> items);
        void MyOtherMethod(MyOtherClass obj);
        void MyOtherMethodOnMultiple(IEnumerable<MyOtherClass> items);
        void MyMethodUsingAnInterface(IMyOtherInterface obj);
    }
}