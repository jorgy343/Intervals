using System;

namespace Jorgy.Invervals
{
    public struct Exclusive<T>
        where T : IComparable<T>
    {
        public Exclusive(T value)
        {
            Value = value;
        }

        public T Value
        {
            get;
        }
    }
}