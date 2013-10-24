using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class MyService : IMyService
    {
        private readonly IMyComponent _component;

        public MyService(IMyComponent component)
        {
            if (component == null) throw new ArgumentNullException("component");
            _component = component;
        }

        public void DoSomething()
        {
            _component.MyMethod();
        }

        public void DoSomething(MyClass obj)
        {
            _component.MyMethod(obj);
        }

        public void DoSomethingDifferent(MyClass obj)
        {
            _component.MyOtherMethod(new MyOtherClass
            {
                MyProperty = obj.MyProperty
            });
        }

        public void DoSomehtingOnMultiple(IEnumerable<MyClass> items)
        {
            _component.MyMethodOnMultiple(items);
        }

        public void DoSomehtingDifferentOnMultiple(IEnumerable<MyClass> items)
        {
            _component.MyOtherMethodOnMultiple(items.Select(x => new MyOtherClass
            {
                MyProperty = x.MyProperty
            }));
        }
    }
}
