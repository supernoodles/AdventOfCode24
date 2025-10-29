using System.Text.RegularExpressions;

namespace Code;

public partial class Day13
{
    public static long Part1(string[] input)
    {
        return FindMinTokens(input);
    }

    public static long Part2(string[] input)
    {
        return FindMinTokens(input, 10000000000000L);
    }


    private static readonly Regex ButtonARegex = BARegex();
    private static readonly Regex ButtonBRegex = BBRegex();
    private static readonly Regex ButtonPRegex = PRegex();

    public static long FindMinTokens(string[] input, long offset = 0L)
    {
        var cost = 0L;

        for (int i = 0; i < input.Length; i += 4)
        {
            var matchA = ButtonARegex.Match(input[i]);

            if (!matchA.Success)
            {
                Console.WriteLine($"Parse failure Button A: {input[i]}");
                return 0;
            }

            var bAX = long.Parse(matchA.Groups["X"].Value);
            var bAY = long.Parse(matchA.Groups["Y"].Value);

            var matchB = ButtonBRegex.Match(input[i + 1]);

            if (!matchB.Success)
            {
                Console.WriteLine($"Parse failure Button B: {input[i + 1]}");
                return 0;
            }

            var bBX = long.Parse(matchB.Groups["X"].Value);
            var bBY = long.Parse(matchB.Groups["Y"].Value);

            var matchP = ButtonPRegex.Match(input[i + 2]);

            if (!matchP.Success)
            {
                Console.WriteLine($"Parse failure Prize: {input[i + 2]}");
                return 0;
            }

            var pX = long.Parse(matchP.Groups["X"].Value) + offset;
            var pY = long.Parse(matchP.Groups["Y"].Value) + offset;

            if ((pX * bBY - pY * bBX) % (bAX * bBY - bBX * bAY) != 0)
            {
                continue;
            }

            var A = (pX * bBY - pY * bBX) / (bAX * bBY - bBX * bAY);
            var B = (pX - bAX * A) / bBX;

            cost += A * 3 + B;
        }

        return cost;
    }

    [GeneratedRegex(@"^Button A: X\+(?<X>\d*?), Y\+(?<Y>\d*?)$")]
    private static partial Regex BARegex();

    [GeneratedRegex(@"^Button B: X\+(?<X>\d*?), Y\+(?<Y>\d*?)$")]
    private static partial Regex BBRegex();

    [GeneratedRegex(@"^Prize: X=(?<X>\d*?), Y=(?<Y>\d\d*?)$")]
    private static partial Regex PRegex();
}
