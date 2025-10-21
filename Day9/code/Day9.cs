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

    private class DiskMapItem(int start, int length, string file = ".")
    {
        public string File { get; set; } = file;
        public int Start { get; set; } = start;
        public int Length { get; set; } = length;
    }

    public long Part2(string input)
    {
        List<DiskMapItem> files = [];
        List<DiskMapItem> spaces = [];

        var position = 0;

        var blocks = input.Index()
            .SelectMany(id =>
            {
                var length = int.Parse($"{id.Item}");

                if (id.Index % 2 == 0)
                {
                    files.Add(new DiskMapItem(position, length, $"{id.Index / 2}"));
                }
                else
                {
                    if (length > 0)
                    {
                        spaces.Add(new DiskMapItem(position, length));
                    }
                }

                position += length;

                var output = id.Index % 2 == 0
                    ? $"{id.Index / 2}"
                    : ".";

                return Enumerable.Repeat(output, length);
            })
            .ToList();

        files.Reverse();

        foreach (var file in files)
        {
            var space = spaces.Find(sp => sp.Start < file.Start && sp.Length >= file.Length);

            if (space == null)
            {
                continue;
            }

            for (int index = 0; index < file.Length; ++index)
            {
                blocks[space.Start + index] = file.File;
                blocks[file.Start + index] = ".";
            }

            space.Length -= file.Length;
            space.Start += file.Length;

            if (space.Length == 0)
            {
                spaces.Remove(space);
            }
        }

        return blocks.Select((block, i) => block != "." ? long.Parse(block) * i : 0).Sum();
    }
}