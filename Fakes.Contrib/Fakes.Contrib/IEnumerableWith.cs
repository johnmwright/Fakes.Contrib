using System;
using System.Collections.Generic;

namespace Fakes.Contrib
{
    public interface IEnumerableWith<out TValue>
    {
        IEnumerable<TOutput> Like<TOutput>(Func<TValue, TOutput, bool> predicate) where TOutput : class;
    }
}