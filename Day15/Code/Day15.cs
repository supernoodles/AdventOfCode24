namespace Code;

public class Day15
{
    public static int Part1(string[] input)
    {
        List<string> map = [];
        List<string> movements = [];

        var width = 0;

        foreach (var line in input.Where(_ => !string.IsNullOrWhiteSpace(_)).Select(_ => _.Trim()))
        {
            if (line.StartsWith('#'))
            {
                map.Add(line);

                if (width == 0)
                {
                    width = line.Length;
                }

                continue;
            }

            movements.Add(line);
        }

        var height = map.Count;

        DisplayMap(map);

        return 0;
    }

    private static void DisplayMap(List<string> map)
    {
        foreach (var line in map)
        {
            Console.WriteLine(line);
        }
    }
}