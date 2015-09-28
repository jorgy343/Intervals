using System;

namespace Jorgy.Intervals
{
    public static class Interval
    {
        // FromInfinity
        public static Interval<T> FromInfinity<T>()
            where T : IComparable<T>
        {
            return new Interval<T>(MinimumEndpoint<T>.Infinity, MaximumEndpoint<T>.Infinity);
        }

        // FromMinimum
        public static Interval<T> FromMinimum<T>(Inclusive<T> minimum)
            where T : IComparable<T>
        {
            return new Interval<T>(new MinimumEndpoint<T>(minimum.Value, IntervalExclusivity.Inclusive), MaximumEndpoint<T>.Infinity);
        }

        public static Interval<T> FromMinimum<T>(Exclusive<T> minimum)
            where T : IComparable<T>
        {
            return new Interval<T>(new MinimumEndpoint<T>(minimum.Value, IntervalExclusivity.Exclusive), MaximumEndpoint<T>.Infinity);
        }

        // FromMaximum
        public static Interval<T> FromMaximum<T>(Inclusive<T> maximum)
            where T : IComparable<T>
        {
            return new Interval<T>(MinimumEndpoint<T>.Infinity, new MaximumEndpoint<T>(maximum.Value, IntervalExclusivity.Inclusive));
        }

        public static Interval<T> FromMaximum<T>(Exclusive<T> maximum)
            where T : IComparable<T>
        {
            return new Interval<T>(MinimumEndpoint<T>.Infinity, new MaximumEndpoint<T>(maximum.Value, IntervalExclusivity.Exclusive));
        }

        // FromBoth
        public static Interval<T> FromBoth<T>(Inclusive<T> minimum, Inclusive<T> maximum)
            where T : IComparable<T>
        {
            return new Interval<T>(new MinimumEndpoint<T>(minimum.Value, IntervalExclusivity.Inclusive), new MaximumEndpoint<T>(maximum.Value, IntervalExclusivity.Inclusive));
        }

        public static Interval<T> FromBoth<T>(Exclusive<T> minimum, Inclusive<T> maximum)
            where T : IComparable<T>
        {
            return new Interval<T>(new MinimumEndpoint<T>(minimum.Value, IntervalExclusivity.Exclusive), new MaximumEndpoint<T>(maximum.Value, IntervalExclusivity.Inclusive));
        }

        public static Interval<T> FromBoth<T>(Inclusive<T> minimum, Exclusive<T> maximum)
            where T : IComparable<T>
        {
            return new Interval<T>(new MinimumEndpoint<T>(minimum.Value, IntervalExclusivity.Inclusive), new MaximumEndpoint<T>(maximum.Value, IntervalExclusivity.Exclusive));
        }

        public static Interval<T> FromBoth<T>(Exclusive<T> minimum, Exclusive<T> maximum)
            where T : IComparable<T>
        {
            return new Interval<T>(new MinimumEndpoint<T>(minimum.Value, IntervalExclusivity.Exclusive), new MaximumEndpoint<T>(maximum.Value, IntervalExclusivity.Exclusive));
        }
    }
}