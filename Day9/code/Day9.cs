using System.Text;

namespace code;

public class Day9
{
    public string Part1(string input)
    {
        var blocksStr = input.Index().Aggregate(new StringBuilder(), (sb, id) =>
        {
            var output = id.Index % 2 == 0
                ? $"{id.Index / 2}"
                : ".";

            for (int i = 0; i < int.Parse($"{id.Item}"); i++)
            {
                sb.Append(output);
            }

            return sb;
        })
        .ToString();

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

        while (blocks[next] != ".")
        {
            ++next;
        }

        int last = blocks.Count - 1;

        while (blocks[last] == ".")
        {
            --last;
        }

        while(next < last)
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

        return blocksStr.ToString();
    }
}