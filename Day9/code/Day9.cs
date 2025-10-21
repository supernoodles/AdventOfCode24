namespace code;

public class Day9
{
    public long Part1(string input)
    {
        var blocks = input.Index()
            .SelectMany(id =>
            {
                var output = id.Index % 2 == 0
                    ? $"{id.Index / 2}"
                    : ".";

                return Enumerable.Repeat(output, int.Parse($"{id.Item}"));
            })
            .ToList();

        int next = 0;

        int last = blocks.Count - 1;

        while (next < last)
        {
            if (blocks[next] != ".")
            {
                ++next;
                continue;
            }

            if (blocks[last] == ".")
            {
                --last;
                continue;
            }

            blocks[next] = blocks[last];
            blocks[last] = ".";
        }

        return blocks.Select((block, i) => block != "." ? long.Parse(block) * i : 0).Sum();
    }
}