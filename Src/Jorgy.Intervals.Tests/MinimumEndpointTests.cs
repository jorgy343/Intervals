using System;
using Jorgy.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jorgy.Intervals.Tests
{
    [TestClass]
    public class MinimumEndpointTests
    {
        private Tuple<int, MinimumEndpoint<int>>[] _minimumEndpointsFromSmallToLarge = new[]
        {
            Tuple.Create(0, MinimumEndpoint<int>.Infinity),
            Tuple.Create(1, new MinimumEndpoint<int>(4, IntervalExclusivity.Inclusive)),
            Tuple.Create(2, new MinimumEndpoint<int>(4, IntervalExclusivity.Exclusive)),
            Tuple.Create(3, new MinimumEndpoint<int>(5, IntervalExclusivity.Inclusive)),
            Tuple.Create(4, new MinimumEndpoint<int>(5, IntervalExclusivity.Exclusive)),
            Tuple.Create(5, new MinimumEndpoint<int>(6, IntervalExclusivity.Inclusive)),
            Tuple.Create(6, new MinimumEndpoint<int>(6, IntervalExclusivity.Exclusive))
        };

        private Tuple<int, MaximumEndpoint<int>>[] _maximumEndpointsFromSmallToLarge = new[]
        {
            Tuple.Create(1, new MaximumEndpoint<int>(4, IntervalExclusivity.Inclusive)),
            Tuple.Create(2, new MaximumEndpoint<int>(4, IntervalExclusivity.Exclusive)),
            Tuple.Create(3, new MaximumEndpoint<int>(5, IntervalExclusivity.Inclusive)),
            Tuple.Create(4, new MaximumEndpoint<int>(5, IntervalExclusivity.Exclusive)),
            Tuple.Create(5, new MaximumEndpoint<int>(6, IntervalExclusivity.Inclusive)),
            Tuple.Create(6, new MaximumEndpoint<int>(6, IntervalExclusivity.Exclusive)),
            Tuple.Create(7, MaximumEndpoint<int>.Infinity)
        };

        [TestMethod]
        public void CompareToTest()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1.CompareTo(right.Item1), left.Item2.CompareTo(right.Item2));
            }
        }

        [TestMethod]
        public void Equals1Test()
        {
            Assert.IsFalse(_minimumEndpointsFromSmallToLarge[0].Item2.Equals(null));
            Assert.IsFalse(_minimumEndpointsFromSmallToLarge[0].Item2.Equals(new object()));

            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 == right.Item1, left.Item2.Equals((object)right.Item2));
            }
        }

        [TestMethod]
        public void Equals2Test()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 == right.Item1, left.Item2.Equals(right.Item2));
            }
        }

        // Test methods for operators related to MinimumEndpoint.
        [TestMethod]
        public void OperatorEqualTo_MinimumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 == right.Item1, left.Item2 == right.Item2);
            }
        }

        [TestMethod]
        public void OperatorNotEqualTo_MinimumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 != right.Item1, left.Item2 != right.Item2);
            }
        }

        [TestMethod]
        public void OperatorLessThan_MinimumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 < right.Item1, left.Item2 < right.Item2);
            }
        }

        [TestMethod]
        public void OperatorLessThanOrEqualTo_MinimumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 <= right.Item1, left.Item2 <= right.Item2);
            }
        }

        [TestMethod]
        public void OperatorGreaterThan_MinimumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 > right.Item1, left.Item2 > right.Item2);
            }
        }

        [TestMethod]
        public void OperatorGreaterThanOrEqualTo_MinimumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _minimumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 >= right.Item1, left.Item2 >= right.Item2);
            }
        }

        // Test methods for operators related to MaximumEndpoint.
        [TestMethod]
        public void OperatorEqualTo_MaximumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _maximumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 == right.Item1, left.Item2 == right.Item2);
            }
        }

        [TestMethod]
        public void OperatorNotEqualTo_MaximumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _maximumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 != right.Item1, left.Item2 != right.Item2);
            }
        }

        [TestMethod]
        public void OperatorLessThan_MaximumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _maximumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 < right.Item1, left.Item2 < right.Item2);
            }
        }

        [TestMethod]
        public void OperatorLessThanOrEqualTo_MaximumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _maximumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 <= right.Item1, left.Item2 <= right.Item2);
            }
        }

        [TestMethod]
        public void OperatorGreaterThan_MaximumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _maximumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 > right.Item1, left.Item2 > right.Item2);
            }
        }

        [TestMethod]
        public void OperatorGreaterThanOrEqualTo_MaximumEndpoint()
        {
            foreach (var left in _minimumEndpointsFromSmallToLarge)
            {
                foreach (var right in _maximumEndpointsFromSmallToLarge)
                    Assert.AreEqual(left.Item1 >= right.Item1, left.Item2 >= right.Item2);
            }
        }
    }
}