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

    public static long Part2(string[] input)
    {
        var computer = new Computer();

        string targetOutput = "";

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
                        targetOutput = value;
                        computer.Program = [.. value.Split(',').Select(int.Parse)];
                        break;
                }
            }
        }

        List<long> aValues = [];
        aValues.Add(0);

        List<long> goodAValues = [];

        while (aValues.Count > 0)
        {
            long a = aValues.First();
            aValues.RemoveAt(0);

            for (int i = 0; i < 8; i++)
            {
                computer.RegisterA = a + i;

                var output = computer.Run();

                if (targetOutput.Equals(output))
                {
                    goodAValues.Add(a + i);
                    continue;
                }

                if (targetOutput.EndsWith(output))
                {
                    aValues.Add((a + i) * 8);
                }
            }
        }

        return goodAValues.Min();
    }

    private static readonly Regex ParseRegex = MyRegex();

    [GeneratedRegex(@"(\w*?): (\d+(?:\s*,\s*\d+)*)", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}