namespace StringCalculator;

public class StringCalculator
{
    public event Action<string, int> AddOccurred = delegate {  };

    private int _calledCount;
    private const string DefaultDelimiter = ",";

    public int Add(string numbers)
    {
        if (numbers == null) throw new ArgumentNullException(nameof(numbers));
        
        var lines = ToLines(numbers).ToList();
        var delimiters = ExtractDelimiters(ref lines);
        var splitNumbers = ExtractNumbers(lines, delimiters);

        EnsureNonNegativeNumbers(splitNumbers, delimiters);

        var sum = Sum(splitNumbers);

        _calledCount++;
        AddOccurred(numbers, sum);
        
        return sum;
    }

    private static int Sum(IEnumerable<string> splitNumbers) =>
        splitNumbers.Select(n => int.Parse(n.ToString()))
            .Where(n => n < 1000)
            .Sum();

    private static void EnsureNonNegativeNumbers(IEnumerable<string> splitNumbers, IEnumerable<string> delimiters)
    {
        var negatives = splitNumbers.Where(n => int.Parse(n.ToString()) < 0).ToList();
        if (negatives.Any())
        {
            throw new ArgumentException($"negative not allowed {string.Join(delimiters.First(), negatives)}");
        }
    }

    private static List<string> ExtractNumbers(IEnumerable<string> lines, List<string> delimiters)
    {
        if (lines == null) throw new ArgumentNullException(nameof(lines));
        if (delimiters == null) throw new ArgumentNullException(nameof(delimiters));
        
        var splits = new List<string>();

        foreach (var line in lines)
        {
            splits.AddRange(
                ToConsistentDelimiter(line, delimiters)
                    .Split(DefaultDelimiter, StringSplitOptions.RemoveEmptyEntries)
                    .ToList());
        }

        return splits;
    }

    private static string ToConsistentDelimiter(string line, IEnumerable<string> delimiters)
    {
        var consistentLine = line;
        foreach (var delimiter in delimiters)
        {
            consistentLine = consistentLine.Replace(delimiter, DefaultDelimiter);
        }

        return consistentLine;
    }

    private static List<string> ToLines(string numbers) => numbers
        .Split('\n', StringSplitOptions.RemoveEmptyEntries)
        .ToList();

    public int GetCalledCount()
    {
        return _calledCount;
    }

    private static List<string> ExtractDelimiters(ref List<string> lines)
    {
        if (lines == null) throw new ArgumentNullException(nameof(lines));
        
        var delimiters = new List<string>();

        if (lines.Any() && lines.First().Length > 1 && lines.First()[..2] == "//")
        {
            var delimiterLine = lines.First();

            delimiterLine = delimiterLine.Replace("/", "");
            delimiterLine = delimiterLine.Replace("[", "");
            delimiters.AddRange(delimiterLine.Split(']', StringSplitOptions.RemoveEmptyEntries).ToList());

            lines.RemoveAt(0);
        }
        else
        {
            delimiters.Add(",");
        }

        return delimiters;
    }
}