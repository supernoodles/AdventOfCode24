namespace Code;

public class Day15
{
    public static int Part1(string[] input)
    {
        List<char[]> map = [];
        List<string> movements = [];

        foreach (var line in input.Where(_ => !string.IsNullOrWhiteSpace(_)).Select(_ => _.Trim()))
        {
            if (line.StartsWith('#'))
            {
                map.Add(line.ToCharArray());

                continue;
            }

            movements.Add(line);
        }

        var height = map.Count;
        var width = map[0].Length;

        var (x, y) = FindGuard(map);

        var moves = movements.SelectMany(_ => _).ToList();

        foreach (var move in moves)
        {
            //Console.WriteLine(move);

            var (dx, dy) = move switch
            {
                '<' => (-1, 0),
                '>' => (1, 0),
                '^' => (0, -1),
                'v' => (0, 1),
                _ => throw new Exception("Bad")
            };

            if (TryPushPart1(map, width, height, x, y, dx, dy))
            {
                (x, y) = (x + dx, y + dy);
            }

            //DisplayMap(map);
        }

        return map.Select((row, ri) =>
            row.Select((col, i) =>
                col == 'O'
                    ? ri * 100 + i
                    : 0)
                .Sum()
            ).Sum();
    }

    public static int Part2(string[] input)
    {
        List<char[]> map = [];
        List<string> movements = [];

        foreach (var line in input.Where(_ => !string.IsNullOrWhiteSpace(_)).Select(_ => _.Trim()))
        {
            if (line.StartsWith('#'))
            {
                var newLine = line.SelectMany(tile =>
                tile switch
                    {
                        '#' => "##",
                        'O' => "[]",
                        '.' => "..",
                        '@' => "@.",
                        _ => throw new Exception("Bad")
                    }
                );

                map.Add([.. newLine]);

                continue;
            }

            movements.Add(line);
        }

        DisplayMap(map);

        var height = map.Count;
        var width = map[0].Length;

        var (x, y) = FindGuard(map);

        var moves = movements.SelectMany(_ => _).ToList();

        foreach (var move in moves)
        {
            Console.WriteLine(move);

            var (dx, dy, h, v) = move switch
            {
                '<' => (-1, 0, true, false),
                '>' => (1, 0, true, false),
                '^' => (0, -1, false, true),
                'v' => (0, 1, false, true),
                _ => throw new Exception("Bad")
            };

            if (h && TryPushH(map, width, height, x, y, dx, dy))
            {
                x += dx;
            }

            if (v && CanPushV(map, width, height, x, y, dy))
            {
                y += dy;
            }

            DisplayMap(map);
        }

        return 0;
    }

    private static bool TryPushH(List<char[]> map, int width, int height, int x, int y, int dx, int dy)
    {
        if (x < 0 || x >= width || y < 0 || y >= height || map[y][x] == '#')
        {
            return false;
        }

        if (map[y][x] == '.')
        {
            return true;
        }

        var moveNext = TryPushH(map, width, height, x + dx, y + dy, dx, dy);

        if (moveNext)
        {
            map[y + dy][x + dx] = map[y][x];
            map[y][x] = '.';

            return true;
        }

        return false;
    }

    private static bool CanPushV(List<char[]> map, int width, int height, int x, int y, int dy)
    {
        if (x < 0 || x >= width || y < 0 || y >= height || map[y][x] == '#')
        {
            return false;
        }

        if (map[y][x] == '.')
        {
            return true;
        }

        var (ox, oy) = map[y][x] switch
        {
            '[' => (x + 1, y),
            ']' => (x - 1, y),
            _ => throw new Exception("Bad")
        };

        var moveNext = CanPushV(map, width, height, x, y + dy, dy) && CanPushV(map, width, height, ox, oy + dy, dy);

        return moveNext;
    }

    private static bool TryPushV(List<char[]> map, int width, int height, int x, int y, int dx, int dy)
    {
        if (x < 0 || x >= width || y < 0 || y >= height || map[y][x] == '#')
        {
            return false;
        }

        if (map[y][x] == '.')
        {
            return true;
        }

        var moveNext = TryPushV(map, width, height, x + dx, y + dy, dx, dy);

        if (moveNext)
        {
            map[y + dy][x + dx] = map[y][x];
            map[y][x] = '.';

            return true;
        }

        return false;
    }

    private static bool TryPushPart1(List<char[]> map, int width, int height, int x, int y, int dx, int dy)
    {
        if (x < 0 || x >= width || y < 0 || y >= height || map[y][x] == '#')
        {
            return false;
        }

        if (map[y][x] == '.')
        {
            return true;
        }

        var moveNext = TryPushPart1(map, width, height, x + dx, y + dy, dx, dy);

        if (moveNext)
        {
            map[y + dy][x + dx] = map[y][x];
            map[y][x] = '.';

            return true;
        }

        return false;
    }

    private static (int x, int y) FindGuard(List<char[]> map)
    {
        var y = map.Index().Where(row => row.Item.Contains('@')).First().Index;
        var x = map[y].Index().Where(col => col.Item.Equals('@')).First().Index;

        return (x, y);
    }

    private static void DisplayMap(List<char[]> map)
    {
        foreach (var line in map)
        {
            Console.WriteLine(line);
        }
    }
}