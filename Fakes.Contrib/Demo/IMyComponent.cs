using System.Collections.Generic;

namespace Demo
{
    public interface IMyComponent
    {
        void MyMethod();
        void MyMethod(MyClass obj);
        void MyOtherMethod(MyOtherClass obj);
        void MyMethodOnMultiple(IEnumerable<MyClass> items);
        void MyOtherMethodOnMultiple(IEnumerable<MyOtherClass> items);
    }
}