using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
            var otherItems = items.Select(x => new MyOtherClass
            {
                MyProperty = x.MyProperty
            }).ToArray();

            if (otherItems.Any())
            {
                _component.MyOtherMethodOnMultiple(otherItems);
            }
        }

        public DateTime ReturnDateTimeNow()
        {
            var now = DateTime.Now;

            return now;
        }

        public Guid ReturnNewGuid()
        {
            var guid = Guid.NewGuid();

            return guid;
        }

        public async Task<string> GoOnTheWeb(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }


        public void DoSomethingWithInterface(IMyOtherInterface obj)
        {
            _component.MyMethodUsingAnInterface(obj);
        }

    }
}
