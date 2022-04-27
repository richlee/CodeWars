namespace BreakCamelCase;

using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class SampleTests
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("camelCasing").Returns("camel Casing");
            yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
        }
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public string Test(string str) => Kata.BreakCamelCase(str);
}