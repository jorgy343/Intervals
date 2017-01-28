// <copyright file="InclusiveTest.cs">Copyright ©  2017</copyright>

using System;
using Jorgy.Intervals;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jorgy.Intervals.IntelliTests
{
    /// <summary>This class contains parameterized unit tests for Inclusive</summary>
    [TestClassAttribute]
    [PexClass(typeof(Inclusive))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class InclusiveTest
    {
    }
}
