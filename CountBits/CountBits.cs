using System.Collections;
using System.Numerics;

namespace CountBits;

public class Kata
{
    public static int CountBits(int n) =>
        (n == 0) ? 0 : (n & 1) + CountBits(n >> 1);
}