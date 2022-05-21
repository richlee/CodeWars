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
        
        foreach (var ch in str)
        {
            if (dict.ContainsKey(ch))
            {
                dict[ch]++;
            }
            else
            {
                dict.Add(ch, 1);
            }
        }
        
        return dict;
    }
}