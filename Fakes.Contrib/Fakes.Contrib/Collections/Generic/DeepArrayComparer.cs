using System.Collections.Generic;
using System.Linq;

namespace Fakes.Contrib.Collections.Generic
{
    public class DeepArrayComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            if (x is IEnumerable<object> && y is IEnumerable<object>)
            {
                return ((IEnumerable<object>)x).SequenceEqual((IEnumerable<object>)y, this);
            }

            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
