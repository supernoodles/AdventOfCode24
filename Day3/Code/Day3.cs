namespace Code;

using System.Text.RegularExpressions;

public partial class Day3
{
    [GeneratedRegex(@"mul\((?<a>\d{1,3}),(?<b>\d{1,3})\)", RegexOptions.IgnoreCase)]
    private static partial Regex MulRegex();

    public int Part1(string input)
    {
        var matches = MulRegex().Matches(input);

        var total = 0;

        foreach (Match match in matches)
        {
            //Console.WriteLine(match.Groups[0]);
            total += int.Parse(match.Groups["a"].Value) * int.Parse(match.Groups["b"].Value);
        }

        return total;
    }

    public int Part2(string input)
    {
        return 0;
    }
}