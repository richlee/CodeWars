namespace TwoSum;

public class Kata
{
    public static IEnumerable<int> TwoSum(int[] numbers, int target)
    {
        for (var x = 0; x < numbers.Length; x++)
        {
            for (var y = 0; y < numbers.Length; y++)
            {
                if (y != x && numbers[x] + numbers[y] == target)
                {
                    return new[] {x, y};
                }
            }
        }

        return Array.Empty<int>();
    }
}