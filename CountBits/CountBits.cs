using System.Collections;
using System.Numerics;

namespace CountBits;

public class Kata
{
    public static int CountBits(int n)
    {
        return (n == 0) ? 0 : (n & 1) + CountBits(n >> 1);
        
        return BitOperations.PopCount((uint) n);
        
        return Convert.ToString(n, toBase: 2).Count(c => c == '1');
        
        var bitArray = new BitArray(new [] {n});
        var bits = new bool[bitArray.Count];
        bitArray.CopyTo(bits, 0);
        return bits.Count(b => b);
    }
}