using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Jorgy.Intervals.IntelliTests
{
    /// <summary>This class contains parameterized unit tests for MinimumEndpoint`1</summary>
    [TestClass]
    [PexClass(typeof(MinimumEndpoint<>))]
    public partial class MinimumEndpointTTest
    {
        [PexMethod]
        [PexGenericArguments(typeof(int))]
        public bool IsValidTest<T>(MinimumEndpoint<T> target, T value)
            where T : IComparable<T>
        {
            var result = target.IsValid(value);
            return result;
        }

        [PexMethod]
        [PexGenericArguments(typeof(int))]
        public int CompareToTest<T>(MinimumEndpoint<T> target, MinimumEndpoint<T> value)
            where T : IComparable<T>
        {
            var result = target.CompareTo(value);
            return result;
        }
    }
}