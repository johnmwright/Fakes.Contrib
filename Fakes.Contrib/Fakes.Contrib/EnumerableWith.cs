using System;
using System.Collections.Generic;
using System.Linq;

namespace Fakes.Contrib
{
    internal class EnumerableWith<TValue> : IEnumerableWith<TValue>
        where TValue : class
    {
        private readonly IEnumerable<TValue> _source;

        public EnumerableWith(IEnumerable<TValue> source)
        {
            _source = source;
        }

        public IEnumerable<TOutput> Like<TOutput>(Func<TValue, TOutput, bool> predicate)
            where TOutput : class
        {
            return _source.Select(item => (Func<TOutput, bool>) (x => predicate(item, x))).Select(With<TOutput>.Like);
        }
    }
}