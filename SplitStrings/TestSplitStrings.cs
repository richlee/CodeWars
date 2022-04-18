using NUnit.Framework;

namespace SplitStrings;

[TestFixture]
public class TestSplitStrings
{
    [Test]
    public void EmptySplit_ReturnsEmptyArray()
    {
        Assert.That(SplitString.Solution(""), Is.EqualTo(Array.Empty<string>()));
    }

    [Test]
    public void OneChar_ReturnsArray()
    {
        Assert.That(SplitString.Solution("a"), Is.EqualTo(new []{"a_"}));
    }

    [Test]
    public void TwoChars_ReturnsArray()
    {
        Assert.That(SplitString.Solution("ab"), Is.EqualTo(new []{"ab"}));
    }
    //
    // [Test]
    // public void FourChars_ReturnsArray()
    // {
    //     Assert.That(SplitString.Solution("abcd"), Is.EqualTo(new []{"ab", "cd"}));
    // }
    
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual(new string[] { "ab", "c_" }, SplitString.Solution("abc"));
        Assert.AreEqual(new string[] { "ab", "cd", "ef" }, SplitString.Solution("abcdef"));
    }

}