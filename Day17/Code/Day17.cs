using System.Text.RegularExpressions;

namespace Code;

public partial class Day17
{
    public static string Part1(string[] input)
    {
        var computer = new Computer();

        foreach (var line in input)
        {
            var match = ParseRegex.Match(line);
            if (match.Success)
            {
                var key = match.Groups[1].Value;
                var value = match.Groups[2].Value;

                switch (key)
                {
                    case "A":
                        computer.RegisterA = int.Parse(value);
                        break;
                    case "B":
                        computer.RegisterB = int.Parse(value);
                        break;
                    case "C":
                        computer.RegisterC = int.Parse(value);
                        break;
                    case "Program":
                        computer.Program = [.. value.Split(',').Select(int.Parse)];
                        break;
                }
            }
        }

        return computer.Run();
    }

    public static string Part2(string[] input)
    {
        return "";
    }

    private static readonly Regex ParseRegex = MyRegex();

    [GeneratedRegex(@"(\w*?): (\d+(?:\s*,\s*\d+)*)", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}