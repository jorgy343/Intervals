﻿using System;

namespace Jorgy.Intervals
{
    public static class Exclusive
    {
        public static Exclusive<T> Value<T>(T value)
            where T : IComparable<T>
        {
            return new Exclusive<T>(value);
        }
    }
}