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

            if (visited.Contains((x, y, dx, dy)))
            {
                continue;
            }

            visited.Add((x, y, dx, dy));

            if (maze[y][x] == '#')
                continue;

            var dir90 = Rotate90(dx, dy);
            var dirMinus90 = RotateMinus90(dx, dy);

            queue.Enqueue((x + dx, y + dy, dx, dy), score + 1);
            queue.Enqueue((x, y, dir90.x, dir90.y), score + 1000);
            queue.Enqueue((x, y, dirMinus90.x, dirMinus90.y), score + 1000);
        }

        return shortest;
    }

    private record MazeState(int X, int Y, int Dx, int Dy);

    private class Path(MazeState state, HashSet<MazeState> visited)
    {
        public MazeState State { get; } = state;
        public HashSet<MazeState> Visited { get; } = visited;
    }

    public static int Part2(string[] input)
    {
        char[][] maze = [.. input.Select(line => line.ToCharArray())];

        var (startX, startY) = FindPos('S', maze);

        Dictionary<MazeState, int> allVisited = [];

        PriorityQueue<Path, int> queue = new();

        var start = new MazeState(startX, startY, 1, 0);

        queue.Enqueue(new Path(start, [start]), 0);

        var shortest = int.MaxValue;
        
        HashSet<(int x, int y)> bestPathTiles = [];

        while (queue.TryDequeue(out var path, out var score))
        {
            if (score > shortest)
            {
                continue;
            }

            var current = path.State;
            var visited = path.Visited;

            if (maze[current.Y][current.X] == 'E')
            {
                if (score < shortest)
                {
                    bestPathTiles = [.. path.Visited.Select(state => (state.X, state.Y))];
                    shortest = score; ;
                    continue;
                }

                bestPathTiles.UnionWith(path.Visited.Select(state => (state.X, state.Y)));

                continue;
            }

            if (!CanVisitTile(allVisited, current, score))
            {
                continue;
            }

            visited.Add(current);

            var nextState = new MazeState(current.X + current.Dx, current.Y + current.Dy, current.Dx, current.Dy);
            if (IsValidTile(maze, nextState.X, nextState.Y) && CanVisitTile(allVisited, nextState, score + 1))
            {
                queue.Enqueue(new Path(nextState, [.. visited]), score + 1);
            }

            var dir90 = Rotate90(current.Dx, current.Dy);
            var dir90State = new MazeState(current.X, current.Y, dir90.x, dir90.y);
            if (CanVisitTile(allVisited, dir90State, score + 1000))
            {
                queue.Enqueue(new Path(dir90State, [.. visited]), score + 1000);
            }

            var dirMinus90 = RotateMinus90(current.Dx, current.Dy);
            var dirMinus90State = new MazeState(current.X, current.Y, dirMinus90.x, dirMinus90.y);
            if (CanVisitTile(allVisited, dirMinus90State, score + 1000))
            {
                queue.Enqueue(new Path(dirMinus90State, [.. visited]), score + 1000);
            }
        }

        return bestPathTiles.Count + 1;
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

    private static bool IsValidTile(char[][] maze, int x, int y) => 
        maze[y][x] == '.' || maze[y][x] == 'E';

    private static bool CanVisitTile(
        Dictionary<MazeState, int> allVisited,
        MazeState state,
        int score)
    {
        if (allVisited.TryGetValue(state, out var existingScore) && existingScore != score)
        {
            return false;
        }

        allVisited[state] = score;
        return true;
    }

    private static void PrintMap(char[][] maze)
    {
        foreach (var row in maze)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine();
    }
}