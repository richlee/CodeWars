namespace CountBits;

using NUnit.Framework;

[TestFixture]
public class TestCountBits
{
    [Test]
    public void CountBits()
    {
        Assert.Multiple(() =>
        {
            Assert.AreEqual(0, Kata.CountBits(0));
            Assert.AreEqual(1, Kata.CountBits(4));
            Assert.AreEqual(3, Kata.CountBits(7));
            Assert.AreEqual(2, Kata.CountBits(9));
            Assert.AreEqual(2, Kata.CountBits(10));
        });
    }
}