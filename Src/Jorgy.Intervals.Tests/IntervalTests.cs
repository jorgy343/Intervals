using Jorgy.Intervals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jorgy.Intervals.Tests
{
    [TestClass]
    public class IntervalTests
    {
        [TestMethod]
        public void ContainsValueTest1()
        {
            var interval = Interval.FromBoth(Inclusive.Value(5), Inclusive.Value(10));

            Assert.IsFalse(interval.Contains(4));
            Assert.IsTrue(interval.Contains(5));
            Assert.IsTrue(interval.Contains(7));
            Assert.IsTrue(interval.Contains(10));
            Assert.IsFalse(interval.Contains(11));
        }

        [TestMethod]
        public void ContainsValueTest2()
        {
            var interval = Interval.FromBoth(Exclusive.Value(5), Exclusive.Value(10));

            Assert.IsFalse(interval.Contains(4));
            Assert.IsFalse(interval.Contains(5));
            Assert.IsTrue(interval.Contains(7));
            Assert.IsFalse(interval.Contains(10));
            Assert.IsFalse(interval.Contains(11));
        }

        [TestMethod]
        public void ContainsValueTest3()
        {
            var interval = Interval.FromMinimum(Inclusive.Value(5));

            Assert.IsFalse(interval.Contains(4));
            Assert.IsTrue(interval.Contains(5));
            Assert.IsTrue(interval.Contains(7));
        }

        [TestMethod]
        public void ContainsValueTest4()
        {
            var interval = Interval.FromMinimum(Exclusive.Value(5));

            Assert.IsFalse(interval.Contains(4));
            Assert.IsFalse(interval.Contains(5));
            Assert.IsTrue(interval.Contains(7));
        }

        [TestMethod]
        public void ContainsValueTest5()
        {
            var interval = Interval.FromMaximum(Inclusive.Value(10));

            Assert.IsTrue(interval.Contains(7));
            Assert.IsTrue(interval.Contains(10));
            Assert.IsFalse(interval.Contains(11));
        }

        [TestMethod]
        public void ContainsValueTest6()
        {
            var interval = Interval.FromMaximum(Exclusive.Value(10));

            Assert.IsTrue(interval.Contains(7));
            Assert.IsFalse(interval.Contains(10));
            Assert.IsFalse(interval.Contains(11));
        }

        [TestMethod]
        public void ContainsIntervalTest1()
        {
            var interval = Interval.FromBoth(Inclusive.Value(5), Inclusive.Value(10));

            Assert.IsTrue(interval.Contains(Interval.FromBoth(Inclusive.Value(7), Inclusive.Value(8))));
            Assert.IsTrue(interval.Contains(Interval.FromBoth(Inclusive.Value(5), Inclusive.Value(10))));
            Assert.IsTrue(interval.Contains(Interval.FromBoth(Exclusive.Value(5), Exclusive.Value(10))));
            Assert.IsFalse(interval.Contains(Interval.FromBoth(Exclusive.Value(4), Exclusive.Value(11))));

            Assert.IsFalse(interval.Contains(Interval.FromMinimum(Exclusive.Value(5))));
            Assert.IsFalse(interval.Contains(Interval.FromMaximum(Exclusive.Value(10))));
        }

        [TestMethod]
        public void ContainsIntervalTest2()
        {
            var interval = Interval.FromBoth(Exclusive.Value(5), Exclusive.Value(10));

            Assert.IsTrue(interval.Contains(Interval.FromBoth(Inclusive.Value(7), Inclusive.Value(8))));
            Assert.IsFalse(interval.Contains(Interval.FromBoth(Inclusive.Value(5), Inclusive.Value(10))));
            Assert.IsTrue(interval.Contains(Interval.FromBoth(Exclusive.Value(5), Exclusive.Value(10))));
            Assert.IsFalse(interval.Contains(Interval.FromBoth(Exclusive.Value(4), Exclusive.Value(11))));

            Assert.IsFalse(interval.Contains(Interval.FromMinimum(Exclusive.Value(5))));
            Assert.IsFalse(interval.Contains(Interval.FromMaximum(Exclusive.Value(10))));
        }

        [TestMethod]
        public void ContainsIntervalTest3()
        {
            var interval = Interval.FromMinimum(Inclusive.Value(5));

            Assert.IsTrue(interval.Contains(Interval.FromBoth(Inclusive.Value(7), Inclusive.Value(8))));
            Assert.IsTrue(interval.Contains(Interval.FromBoth(Inclusive.Value(5), Inclusive.Value(10))));
            Assert.IsTrue(interval.Contains(Interval.FromBoth(Exclusive.Value(5), Exclusive.Value(10))));
            Assert.IsFalse(interval.Contains(Interval.FromBoth(Exclusive.Value(4), Exclusive.Value(11))));

            Assert.IsTrue(interval.Contains(Interval.FromMinimum(Exclusive.Value(5))));
            Assert.IsFalse(interval.Contains(Interval.FromMaximum(Exclusive.Value(10))));
        }

        [TestMethod]
        public void ContainsIntervalTest4()
        {
            var interval = Interval.FromMaximum(Inclusive.Value(10));

            Assert.IsTrue(interval.Contains(Interval.FromBoth(Inclusive.Value(7), Inclusive.Value(8))));
            Assert.IsTrue(interval.Contains(Interval.FromBoth(Inclusive.Value(5), Inclusive.Value(10))));
            Assert.IsTrue(interval.Contains(Interval.FromBoth(Exclusive.Value(5), Exclusive.Value(10))));
            Assert.IsFalse(interval.Contains(Interval.FromBoth(Exclusive.Value(4), Exclusive.Value(11))));

            Assert.IsFalse(interval.Contains(Interval.FromMinimum(Exclusive.Value(5))));
            Assert.IsTrue(interval.Contains(Interval.FromMaximum(Exclusive.Value(10))));
        }
    }
}