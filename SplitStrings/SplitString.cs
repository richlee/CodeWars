namespace SplitStrings;

/// <summary>
/// Complete the solution so that it splits the string into pairs of two characters.
/// If the string contains an odd number of characters then it should replace the missing
/// second character of the final pair with an underscore ('_').
///
/// Examples:
/// 
/// * 'abc' =>  ['ab', 'c_']
/// * 'abcdef' => ['ab', 'cd', 'ef']
/// </summary>
public static class SplitString
{
    public static string[] Solution(string input)
    {
        var result = new List<string>();

        for (var i = 0; i < input.Length; i++)
        {
            result.Add(input[i] +
                       (i + 1 < input.Length
                           ? input[++i].ToString()
                           : "_"));
        }

        return result.ToArray();

    }
}