namespace Squares;

public class Kata
{
    public static bool IsSquare(int n)
    {
        return Math.Sqrt(n) % 1 == 0;
        
        if (n < 0) return false;
        
        var sqrt = Math.Sqrt(n);
        var roundedSqrt = Math.Round(sqrt, MidpointRounding.ToZero);
        return sqrt.CompareTo(roundedSqrt) == 0;
    }
}