using System;

namespace Jorgy.Invervals
{
    public struct Interval<T>
        where T : IComparable<T>
    {
        public Interval(MinimumEndpoint<T> minimum, MaximumEndpoint<T> maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public bool Contains(T value)
        {
            return Minimum.IsValid(value) && Maximum.IsValid(value);
        }
        /*
        public bool Contains(Interval<T> interval)
        {
            // Compare minimums.
            if (!MinimumIsInfinite)
            {
                if (interval.MinimumIsInfinite)
                    return false;

                int compareValue = Minimum.CompareTo(interval.Minimum);
                if (MinimumIsInclusive && compareValue > 0)
                    return false;

                if (!MinimumIsInclusive && interval.MinimumIsInclusive && compareValue >= 0)
                    return false;

                if (compareValue > 0)
                    return false;
            }

            // Compare maximums.
            if (!MaximumIsInfinite)
            {
                if (interval.MaximumIsInfinite)
                    return false;

                int compareValue = Maximum.CompareTo(interval.Maximum);
                if (MaximumIsInclusive && compareValue < 0)
                    return false;

                if (!MaximumIsInclusive && interval.MaximumIsInclusive && compareValue <= 0)
                    return false;

                if (compareValue < 0)
                    return false;
            }

            return true;
        }

        public Interval<T>? Intersects(Interval<T> interval)
        {
            T minimum = default(T);
            bool minimumIsInfinite = false;
            bool minimumIsInclusive = false;

            // Is the minimum infinite?
            if (MinimumIsInfinite && interval.MinimumIsInfinite)
            {
                minimumIsInfinite = true;
            }
            else if (MinimumIsInfinite)
            {
                minimum = interval.Minimum;
                minimumIsInclusive = interval.MinimumIsInclusive;
            }
            else if (interval.MinimumIsInfinite)
            {
                minimum = Minimum;
                minimumIsInclusive = MinimumIsInclusive;
            }

            return null;
        }
        */
        public override string ToString()
        {
            string leftBrace = Minimum.Exclusivity == IntervalExclusivity.Inclusive ? "[" : "(";
            string rightBrace = Maximum.Exclusivity == IntervalExclusivity.Inclusive ? "]" : ")";

            string leftValue = Minimum.IsInfinity ? "∞" : Minimum.ToString();
            string rightValue = Maximum.IsInfinity ? "∞" : Maximum.ToString();

            return $"{leftBrace}{leftValue}, {rightValue}{rightBrace}";
        }

        public bool IsValid
        {
            get
            {
                // Boundless range.
                if (Minimum.IsInfinity && Maximum.IsInfinity)
                    return true;

                // Bounded infinite range.
                if (Minimum.IsInfinity ^ Maximum.IsInfinity)
                    return true;

                // Bounded range.
                return Minimum.Value.CompareTo(Maximum.Value) <= 0; // TODO: Does this consider exclusivity?
            }
        }

        public MinimumEndpoint<T> Minimum
        {
            get;
        }

        public MaximumEndpoint<T> Maximum
        {
            get;
        }
    }
}