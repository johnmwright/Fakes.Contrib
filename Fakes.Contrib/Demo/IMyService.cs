using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo
{
    public interface IMyService
    {
        void DoSomething();
        void DoSomething(MyClass obj);
        void DoSomethingDifferent(MyClass obj);
        void DoSomehtingOnMultiple(IEnumerable<MyClass> items);
        void DoSomehtingDifferentOnMultiple(IEnumerable<MyClass> items);
        DateTime ReturnDateTimeNow();
        Guid ReturnNewGuid();
        Task<string> GoOnTheWeb(string url);
        void DoSomethingWithInterface(IMyOtherInterface obj);
    }
}