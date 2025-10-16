using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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

                guardX = nextX;
                guardY = nextY;
                continue;
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

            //PrintMap(map);
        }
    }

    record Guard(int X, int Y, int VX, int VY);

    public int Part2(string[] input)
    {
        char[][] guardMap = [.. input.Select(s => s.ToCharArray())];

        var (guardInitX, guardInitY) = FindGuard(guardMap);

        var (guardInitVelX, guardInitVelY) = (0, -1);

        PrintMap(guardMap);

        FindGuardRoute(guardMap);

        var guardDefault = new Guard(-1, -1, -1, -1);

        var guardLoop = 0;

        for (int iX = 0; iX < guardMap[0].Length; ++iX)
        {
            for (int iY = 0; iY < guardMap.Length; ++iY)
            {
                Guard oGuard = guardDefault;

                if (guardMap[iY][iX] != 'X')
                {
                    continue;
                }

                char[][] map = [.. input.Select(s => s.ToCharArray())];

                // map[iY][iX] = 'O';
                map[30][9] = 'O';

                var (guardX, guardY, velX, velY) = (guardInitX, guardInitY, guardInitVelX, guardInitVelY);

                while (GuardInBounds(map, guardX, guardY))
                {
                    var nextX = guardX + velX;
                    var nextY = guardY + velY;

                    if (!GuardInBounds(map, nextX, nextY))
                    {
                        guardX = nextX;
                        guardY = nextY;

                        continue;
                    }

                    var next = map[nextY][nextX];

                    if (next == '#' || next == 'O')
                    {
                        (velX, velY) = Rotate90(velX, velY);

                        if (next == '#')
                        {
                            continue;
                        }

                        if (oGuard == guardDefault)
                        {
                            oGuard = new Guard(guardX, guardY, velX, velY);
                            continue;
                        }

                        if (oGuard == new Guard(guardX, guardY, velX, velY))
                        {
                            guardLoop += 1;
                            break;
                        }
                    }

                    map[guardY][guardX] = 'X';
                    map[nextY][nextX] = '^';

                    guardX = nextX;
                    guardY = nextY;

                    PrintMap(map);


                    Thread.Sleep(100);
                    //Console.ReadLine();
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