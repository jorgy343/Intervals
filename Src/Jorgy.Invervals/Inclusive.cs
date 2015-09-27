using System;

namespace Jorgy.Invervals
{
    public static class Inclusive
    {
        public static Inclusive<T> Value<T>(T value)
            where T : IComparable<T>
        {
            return new Inclusive<T>(value);
        }
    }
}