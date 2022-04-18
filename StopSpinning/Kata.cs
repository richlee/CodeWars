using System.Text;

namespace StopSpinning;

/// <summary>
/// Write a function that takes in a string of one or more words, and returns the
/// same string, but with all five or more letter words reversed (Just like the
/// name of this Kata). Strings passed in will consist of only letters and spaces.
/// Spaces will be included only when more than one word is present.
///Examples: spinWords( "Hey fellow warriors" ) => returns "Hey wollef sroirraw"
/// spinWords( "This is a test") => returns "This is a test"
/// spinWords( "This is another test" )=> returns "This is rehtona test"
/// </summary>
public static class Kata
{
    public static string SpinWords(string sentence)
    {
        return string
            .Join(" ", 
                sentence
                    .Split(" ")
                    .Select(word => word.Length >= 5 
                        ? new string(word.Reverse().ToArray()) 
                        : word));
        
        var words = sentence.Split(" ");

        var results = new StringBuilder();

        for (var idxWord = 0; idxWord < words.Length; idxWord++)
        {
            var word = words[idxWord];
            if (word.Length < 5)
            {
                results.Append(word);
            }
            else
            {
                results.Append(word.Reverse());
            }

            if (idxWord + 1 < words.Length)
            {
                results.Append(' ');
            }
        }

        return results.ToString();
    }
}