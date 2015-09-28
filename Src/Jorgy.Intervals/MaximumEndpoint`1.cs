using System;

namespace Jorgy.Intervals
{
    public struct MaximumEndpoint<T> : IComparable<MaximumEndpoint<T>>, IEquatable<MaximumEndpoint<T>>
        where T : IComparable<T>
    {
        public static readonly MaximumEndpoint<T> Infinity = new MaximumEndpoint<T>(default(T), IntervalExclusivity.Exclusive, true);

        public MaximumEndpoint(T value, IntervalExclusivity exclusivity, bool isInfinity = false)
        {
            Value = value;
            IsInfinity = isInfinity;
            Exclusivity = exclusivity;
        }

        public bool IsValid(T value)
        {
            if (IsInfinity)
                return true;

            int comparison = Value.CompareTo(value);
            if (comparison == 1)
                return true;

            if (comparison == -1)
                return false;

            if (comparison == 0 && Exclusivity == IntervalExclusivity.Inclusive)
                return true;

            return false;
        }

        public int CompareTo(MaximumEndpoint<T> other)
        {
            if (this < other)
                return -1;

            if (this > other)
                return 1;

            return 0;
        }

        public bool Equals(MaximumEndpoint<T> other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is MaximumEndpoint<T>))
                return false;

            return this == (MaximumEndpoint<T>)obj;
        }

        public override int GetHashCode()
        {
            if (IsInfinity)
                return IsInfinity.GetHashCode();

            return Value.GetHashCode() ^ Exclusivity.GetHashCode();
        }

        #region Operators for MaximumEndpoint`1

        public static bool operator ==(MaximumEndpoint<T> left, MaximumEndpoint<T> right)
        {
            // Infinity ignores the actual value and exclusivity.
            if (left.IsInfinity && right.IsInfinity)
                return true;
            else if (left.IsInfinity ^ right.IsInfinity)
                return false;

            return left.Value.CompareTo(right.Value) == 0 && left.Exclusivity == right.Exclusivity;
        }

        public static bool operator !=(MaximumEndpoint<T> left, MaximumEndpoint<T> right)
        {
            return !(left == right); // Defined in terms of the == operator due to laziness.
        }

        public static bool operator <(MaximumEndpoint<T> left, MaximumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.
            if (left.IsInfinity && right.IsInfinity)
                return false;

            if (left.IsInfinity) // Right cannot be infinity here.
                return false;

            if (right.IsInfinity) // Left cannot be infinity here.
                return true;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison < 0)
                return true;

            if (comparison == 0)
            {
                // If the left is inclusive and the right is exclusive and both values are equal, the left is smaller than the right.
                if (left.Exclusivity == IntervalExclusivity.Inclusive && right.Exclusivity == IntervalExclusivity.Exclusive)
                    return true;
            }

            return false;
        }

        public static bool operator <=(MaximumEndpoint<T> left, MaximumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.
            if (left.IsInfinity && right.IsInfinity)
                return true;

            if (left.IsInfinity) // Right cannot be infinity here.
                return false;

            if (right.IsInfinity) // Left cannot be infinity here.
                return true;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison < 0)
                return true;

            if (comparison == 0)
            {
                if (left.Exclusivity == right.Exclusivity)
                    return true;

                // If the left is inclusive and the right is exclusive and both values are equal, the left is smaller than the right.
                if (left.Exclusivity == IntervalExclusivity.Inclusive && right.Exclusivity == IntervalExclusivity.Exclusive)
                    return true;
            }

            return false;
        }

        public static bool operator >(MaximumEndpoint<T> left, MaximumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.
            if (left.IsInfinity && right.IsInfinity)
                return false;

            if (left.IsInfinity) // Right cannot be infinity here.
                return true;

            if (right.IsInfinity) // Left cannot be infinity here.
                return false;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison > 0)
                return true;

            if (comparison == 0)
            {
                // If the left is exclusive and the right is inclusive and both values are equal, the left is larger than the right.
                if (left.Exclusivity == IntervalExclusivity.Exclusive && right.Exclusivity == IntervalExclusivity.Inclusive)
                    return true;
            }

            return false;
        }

        public static bool operator >=(MaximumEndpoint<T> left, MaximumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.
            if (left.IsInfinity && right.IsInfinity)
                return true;

            if (left.IsInfinity) // Right cannot be infinity here.
                return true;

            if (right.IsInfinity) // Left cannot be infinity here.
                return false;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison > 0)
                return true;

            if (comparison == 0)
            {
                if (left.Exclusivity == right.Exclusivity)
                    return true;

                // If the left is exclusive and the right is inclusive and both values are equal, the left is larger than the right.
                if (left.Exclusivity == IntervalExclusivity.Exclusive && right.Exclusivity == IntervalExclusivity.Inclusive)
                    return true;
            }

            return false;
        }

        #endregion

        #region Operators for MinimumEndpoint`1

        public static bool operator ==(MaximumEndpoint<T> left, MinimumEndpoint<T> right)
        {
            if (left.IsInfinity || right.IsInfinity)
                return false;

            return left.Value.CompareTo(right.Value) == 0 && left.Exclusivity == right.Exclusivity;
        }

        public static bool operator !=(MaximumEndpoint<T> left, MinimumEndpoint<T> right)
        {
            return !(left == right); // Defined in terms of the == operator due to laziness.
        }

        public static bool operator <(MaximumEndpoint<T> left, MinimumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.            
            if (left.IsInfinity || right.IsInfinity)
                return false;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison < 0)
                return true;

            if (comparison == 0)
            {
                // If the left is inclusive and the right is exclusive and both values are equal, the left is smaller than the right.
                if (left.Exclusivity == IntervalExclusivity.Inclusive && right.Exclusivity == IntervalExclusivity.Exclusive)
                    return true;
            }

            return false;
        }

        public static bool operator <=(MaximumEndpoint<T> left, MinimumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.
            if (left.IsInfinity || right.IsInfinity)
                return false;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison < 0)
                return true;

            if (comparison == 0)
            {
                if (left.Exclusivity == right.Exclusivity)
                    return true;

                // If the left is inclusive and the right is exclusive and both values are equal, the left is smaller than the right.
                if (left.Exclusivity == IntervalExclusivity.Inclusive && right.Exclusivity == IntervalExclusivity.Exclusive)
                    return true;
            }

            return false;
        }

        public static bool operator >(MaximumEndpoint<T> left, MinimumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.
            if (left.IsInfinity || right.IsInfinity)
                return true;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison > 0)
                return true;

            if (comparison == 0)
            {
                // If the left is exclusive and the right is inclusive and both values are equal, the left is larger than the right.
                if (left.Exclusivity == IntervalExclusivity.Exclusive && right.Exclusivity == IntervalExclusivity.Inclusive)
                    return true;
            }

            return false;
        }

        public static bool operator >=(MaximumEndpoint<T> left, MinimumEndpoint<T> right)
        {
            // Treat infinity as you would on the extended real number line.
            if (left.IsInfinity || right.IsInfinity)
                return true;

            int comparison = left.Value.CompareTo(right.Value);
            if (comparison > 0)
                return true;

            if (comparison == 0)
            {
                if (left.Exclusivity == right.Exclusivity)
                    return true;

                // If the left is exclusive and the right is inclusive and both values are equal, the left is larger than the right.
                if (left.Exclusivity == IntervalExclusivity.Exclusive && right.Exclusivity == IntervalExclusivity.Inclusive)
                    return true;
            }

            return false;
        }

        #endregion

        public T Value
        {
            get;
        }

        public IntervalExclusivity Exclusivity
        {
            get;
        }

        public bool IsInfinity
        {
            get;
        }
    }
}