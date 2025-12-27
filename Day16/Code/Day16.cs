namespace Code;

public static class Day16
{
    public static int Part1(string[] input)
    {
        char[][] maze = [.. input.Select(line => line.ToCharArray())];

        var (startX, startY) = FindPos('S', maze);

        var (dirX, dirY) = (1, 0);

        var (shortest, path) = Recurse(maze, startX, startY, dirX, dirY, 0, []);

        foreach (var (vX, vY, vDirX, vDirY) in path)
        {
            if(maze[vY][vX] == 'S' || maze[vY][vX] == 'E')
                continue;

            maze[vY][vX] = (vDirX, vDirY) switch
            {
                (1, 0) => '>',
                (0, 1) => 'v',
                (-1, 0) => '<',
                (0, -1) => '^',
                _ => '?'
            };
        }

        PrintMap(maze);

        return shortest;
    }

    private static readonly HashSet<(int x, int y, int dx, int dy)> _visited = [];

    private static (int,HashSet<(int x, int y, int dx, int dy)>) 
        Recurse(char[][] maze, int X, int Y, int dirX, int dirY, int score, HashSet<(int x, int y, int dx, int dy)> path)
    {
        if(path.Contains((X, Y, dirX, dirY)))
        {
            //Console.WriteLine($"Already visited {X},{Y}, skipping");
            return (int.MaxValue, []);
        }

        path.Add((X, Y, dirX, dirY));

        //Console.WriteLine($"Visiting {X},{Y} facing {dirX},{dirY} with score {score}");

        if(maze[Y][X] == 'E')
        {
            return (score, path);
        }

        var dir90 = Rotate90(dirX, dirY);
        var dirMinus90 = RotateMinus90(dirX, dirY);

        var ahead = maze[Y + dirY][X + dirX];
        var clockwise = maze[Y + dir90.y][X + dir90.x];
        var anticlockwise = maze[Y + dirMinus90.y][X + dirMinus90.x];

        if (ahead == '#' && clockwise == '#' && anticlockwise == '#')
        {
            return (int.MaxValue, []);
        }

        var scores = new (int, HashSet<(int x, int y, int dx, int dy)>)[] {
            ahead != '#' ? Recurse(maze, X + dirX, Y + dirY, dirX, dirY, score + 1, [.. path]) : (int.MaxValue, []),
            clockwise != '#' ? Recurse(maze, X + dir90.x, Y + dir90.y, dir90.x, dir90.y, score + 1001, [.. path]) : (int.MaxValue, []),
            anticlockwise != '#' ? Recurse(maze, X + dirMinus90.x, Y + dirMinus90.y, dirMinus90.x, dirMinus90.y, score + 1001, [.. path]) : (int.MaxValue, [])
        };

        var minScore = scores.Min(item => item.Item1);
        var minPath = scores.First(item => item.Item1 == minScore).Item2;

        return (minScore, minPath);
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