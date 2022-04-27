namespace ArrayDiff;

public static class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        return a.Where(x => !b.Contains(x)).ToArray();
    }
}