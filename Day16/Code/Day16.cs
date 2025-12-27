namespace Code;

public static class Day16
{
    public static int Part1(string[] input)
    {
        char[][] maze = [.. input.Select(line => line.ToCharArray())];

        var (startX, startY) = FindPos('S', maze);

        var (dirX, dirY) = (1, 0);

        PriorityQueue<(int x, int y, int dx, int dy), int> queue = 
            new();

        HashSet<(int x, int y, int dx, int dy)> visited = 
            [];

        queue.Enqueue((startX, startY, dirX, dirY), 0);

        var shortest = int.MaxValue;

        while (queue.TryDequeue(out var item, out var score))
        {
            var (x, y, dx, dy) = item;

            if (maze[y][x] == 'E')
            {
                shortest = Math.Min(shortest, score);
                continue;
            }

            if(visited.Contains((x, y, dx, dy)))
            {
                continue;
            }

            visited.Add((x, y, dx, dy));

            if (maze[y][x] == '#')
                continue;

            var dir90 = Rotate90(dx, dy);
            var dirMinus90 = RotateMinus90(dx, dy);

            queue.Enqueue((x + dx, y + dy, dx, dy), score + 1);
            queue.Enqueue((x + dir90.x, y + dir90.y, dir90.x, dir90.y), score + 1001);
            queue.Enqueue((x + dirMinus90.x, y + dirMinus90.y, dirMinus90.x, dirMinus90.y), score + 1001);
        }

        return shortest;
    }

    public static int Part2(string[] input)
    {
        return 0;
    }

    private static (int x, int y) FindPos(char toFind, char[][] maze)
    {
        var y = maze.Index().First(row => row.Item.Contains(toFind)).Index;
        var x = maze[y].Index().First(col => col.Item.Equals(toFind)).Index;

        return (x, y);
    }

    private static (int x, int y) Rotate90(int x, int y) =>
        (-y,
        x);

    private static (int x, int y) RotateMinus90(int x, int y) =>
        (y,
        -x);

    private static void PrintMap(char[][] maze)
    {
        foreach (var row in maze)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine();
    }
}