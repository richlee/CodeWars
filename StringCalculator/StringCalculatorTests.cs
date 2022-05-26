namespace StringCalculator;

using NUnit.Framework;

[TestFixture]
public class StringCalculatorTests
{
    private StringCalculator calc = new StringCalculator();

    [SetUp]
    public void Setup()
    {
        calc.AddOccurred += delegate
        {
        };
    }

    [TestCase("", 0)]
    [TestCase("1", 1)]
    [TestCase("1,2", 3)]
    [TestCase("1,2,3", 6)]
    [TestCase($"1\n2,3", 6)]
    [TestCase($"//;\n2;3", 5)]
    [TestCase($"//;\n1\n2;3", 6)]
    [TestCase("1001,2", 2)]
    [TestCase("//[***]\n1***2***3", 6)]
    [TestCase("//[*][%]\n1*2%3", 6)]
    [TestCase("//[**][%%]\n1**2%%3", 6)]
    [TestCase("//[**][%%]\n1**2%%3\n4", 10)]
    public void When_Input_Returns_Result(string input, int result)
    {
        Assert.That(calc.Add(input), Is.EqualTo(result));
    }

    [TestCase("-1")]
    [TestCase("-1,-2")]
    public void When_Negative_Throws(string input)
    {
        var ex = Assert.Throws<ArgumentException>(
            () => calc.Add(input)
        );
        
        Assert.That(ex.Message, Is.EqualTo($"negative not allowed {input}"));
    }

    [Test]
    public void CalledCount_ReturnsCount()
    {
        calc.Add("1");
        Assert.That(calc.GetCalledCount(), Is.EqualTo(1));
        calc.Add("1");
        Assert.That(calc.GetCalledCount(), Is.EqualTo(2));
    }

    [Test]
    public void When_Added_EventFires()
    {
        var givenInput = "";
        var finalResult = -1;
        calc.AddOccurred += delegate(string input, int result)
        {
            givenInput = input;
            finalResult = result;
        };

        calc.Add("1");
        
        Assert.That(givenInput, Is.EqualTo("1"));
        Assert.That(finalResult, Is.EqualTo(1));
    }
}