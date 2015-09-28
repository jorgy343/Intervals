using System;

namespace Jorgy.Intervals
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
        
        public bool Contains(Interval<T> interval)
        {
            return Minimum <= interval.Minimum && Maximum >= interval.Maximum;
        }

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