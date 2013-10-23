using System.Collections.Generic;
using System.Linq;

namespace Fakes.Contrib.Collections.Generic
{
    public class DeepArrayComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            if (x is object[] && y is object[])
            {
                return ((object[])x).SequenceEqual((object[])y, this);
            }

            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
