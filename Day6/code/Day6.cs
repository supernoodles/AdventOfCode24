using System.Data;

namespace code;

public class Day6
{
    public int Part1(string[] input)
    {
        char[][] map = [.. input.Select(s => s.ToCharArray())];

        PrintMap(map);

        FindGuardRoute(map);

        return map.SelectMany(row => row).Where(pos => pos == 'X').Count();
    }

    private void FindGuardRoute(char[][] map)
    {
        var (guardX, guardY) = FindGuard(map);

        var velX = 0;
        var velY = -1;

        while (GuardInBounds(map, guardX, guardY))
        {
            var nextX = guardX + velX;
            var nextY = guardY + velY;

            if (!GuardInBounds(map, nextX, nextY))
            {
                map[guardY][guardX] = 'X';

                break;
            }

            var next = map[nextY][nextX];

            if (next == '#')
            {
                (velX, velY) = Rotate90(velX, velY);
                continue;
            }

            map[guardY][guardX] = 'X';
            map[nextY][nextX] = '^';

            guardX = nextX;
            guardY = nextY;
        }
    }

    record Guard(int X, int Y, int VX, int VY);

    public int Part2(string[] input)
    {
        char[][] guardMap = [.. input.Select(s => s.ToCharArray())];

        var (guardInitX, guardInitY) = FindGuard(guardMap);

        var (guardInitVelX, guardInitVelY) = (0, -1);

        FindGuardRoute(guardMap);

        var guardDefault = new Guard(-1, -1, -1, -1);

        HashSet<Guard> guardPath = [];

        var guardLoop = 0;

        for (int iX = 0; iX < guardMap[0].Length; ++iX)
        {
            for (int iY = 0; iY < guardMap.Length; ++iY)
            {
                if (guardMap[iY][iX] != 'X')
                {
                    continue;
                }

                guardPath.Clear();

                char[][] map = [.. input.Select(s => s.ToCharArray())];

                map[iY][iX] = 'O';

                var (guardX, guardY, velX, velY) = (guardInitX, guardInitY, guardInitVelX, guardInitVelY);

                while (GuardInBounds(map, guardX, guardY))
                {
                    var nextX = guardX + velX;
                    var nextY = guardY + velY;

                    if (!GuardInBounds(map, nextX, nextY))
                    {
                        break;
                    }

                    var next = map[nextY][nextX];

                    if (next == '#' || next == 'O')
                    {
                        (velX, velY) = Rotate90(velX, velY);

                        continue;
                    }

                    map[guardY][guardX] = 'X';
                    map[nextY][nextX] = '^';

                    guardX = nextX;
                    guardY = nextY;

                    var currentGuardState = new Guard(guardX, guardY, velX, velY);

                    if (guardPath.Contains(currentGuardState))
                    {
                        ++guardLoop;
                        break;
                    }

                    guardPath.Add(currentGuardState);
                }
            }
        }

        return guardLoop;
    }

    private bool GuardInBounds(char[][] map, int guardX, int guardY) =>
        guardX >= 0 && guardX < map[0].Length &&
        guardY >= 0 && guardY < map.Length;


    private (int x, int y) Rotate90(int x, int y) =>
        (-y,
        x);

    private (int x, int y) FindGuard(char[][] map)
    {
        var y = map.Index().Where(row => row.Item.Contains('^')).First().Index;
        var x = map[y].Index().Where(col => col.Item.Equals('^')).First().Index;

        return (x, y);
    }

    private void PrintMap(char[][] map)
    {
        foreach (var row in map)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine();
    }
}