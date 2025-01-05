namespace Code;

using System.Text.RegularExpressions;

public partial class Day3
{
    [GeneratedRegex(@"mul\((?<a>\d{1,3}),(?<b>\d{1,3})\)", RegexOptions.IgnoreCase)]
    private static partial Regex MulRegex();

    [GeneratedRegex(@"(?<i>do)\(\)|(?<i>don't)\(\)|(?<i>mul)\((?<a>\d{1,3}),(?<b>\d{1,3})\)", RegexOptions.IgnoreCase)]
    private static partial Regex Combined();

    public static int Part1(string input) =>
        MulRegex().Matches(input)
            .Cast<Match>()
            .Sum(_ => int.Parse(_.Groups["a"].Value) * int.Parse(_.Groups["b"].Value));

    public static int Part2(string input)
    {
        bool include = true;

        return Combined().Matches(input).Cast<Match>()
            .Sum(item => {
                if(include && item.Groups["i"].Value == "mul")
                {
                    return int.Parse(item.Groups["a"].Value) * int.Parse(item.Groups["b"].Value);
                }

                if(item.Groups["i"].Value == "do")
                {
                    include = true;
                }

                if(item.Groups["i"].Value == "don't")
                {
                    include = false;
                }

                return 0;
            });
    }
}