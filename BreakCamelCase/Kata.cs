using System.Linq;
namespace BreakCamelCase;

public class Kata
{
    public static string BreakCamelCase(string str) =>
        string.Concat(str.Select(ch => char.IsUpper(ch) ? $" {ch}" : $"{ch}"));
}