// For examples, see:
// https://thegraybook.vvvv.org/reference/extending/writing-nodes.html#examples

using Stride.Core;

namespace VL.Fixtures;

public static class Core
{
    public static float DemoNode(float a, float b)
    {
        return a + b;
    }

    public static int FromByteArray(Spread<byte> bytes, bool isLittleEndian=true)
    {


        var count = bytes.Count * 8 -8;
        var value = 0;
        if (isLittleEndian) 
            bytes =bytes.Reverse().ToSpread();
        foreach (byte b in bytes)
        {
            value += b << count; 
            count -= 8;
        }
        return value;
    }
}

