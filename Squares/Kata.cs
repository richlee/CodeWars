namespace Squares;

public class Kata
{
    public static bool IsSquare(int n)
    {
        return Math.Sqrt(n) % 1 == 0;
    }
}