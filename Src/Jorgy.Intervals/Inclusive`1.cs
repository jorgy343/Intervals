using System;

namespace Jorgy.Intervals
{
    public struct Inclusive<T>
        where T : IComparable<T>
    {
        public Inclusive(T value)
        {
            Value = value;
        }

        public T Value
        {
            get;
        }
    }
}