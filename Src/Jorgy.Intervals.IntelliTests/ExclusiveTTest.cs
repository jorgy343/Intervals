// <copyright file="ExclusiveTTest.cs">Copyright ©  2017</copyright>

using System;
using Jorgy.Intervals;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jorgy.Intervals.IntelliTests
{
    /// <summary>This class contains parameterized unit tests for Exclusive`1</summary>
    [TestClassAttribute]
    [PexClass(typeof(Exclusive<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ExclusiveTTest
    {
    }
}
