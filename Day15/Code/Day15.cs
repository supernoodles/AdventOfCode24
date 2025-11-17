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

            if (TryPush(map, width, height, x, y, dx, dy))
            {
                (x, y) = (x+dx, y+dy);
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

    private static bool TryPush(List<char[]> map, int width, int height, int x, int y, int dx, int dy)
    {
        if (x < 0 || x >= width || y < 0 || y >= height || map[y][x] == '#')
        {
            return false;
        }

        if (map[y][x] == '.')
        {
            return true;
        }

        var moveNext = TryPush(map, width, height, x + dx, y + dy, dx, dy);

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