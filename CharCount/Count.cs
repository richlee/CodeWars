namespace CharCount;

public class Kata
{
    public static Dictionary<char, int> Count(string str)
    {
        var dict = new Dictionary<char, int>();

        foreach (var c in str)
        {
            dict.TryGetValue(c, out var count);
            dict[c] = ++count;
        }

        return dict;
    }
}