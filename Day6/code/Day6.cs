namespace code;

public class Day6
{
    public int Part1(string[] input)
    {
        char[][] map = [.. input.Select(s => s.ToCharArray())];

        PrintMap(map);

        var (guardX, guardY) = FindGuard(map);

        var velX = 0;
        var velY = -1;

        while (guardInBounds(map, guardX, guardY))
        {
            var next = map[guardY + velY][guardX + velX];

            if (next == '.')
            {
                map[guardY][guardX] = '.';
                guardX += velX;
                guardY += velY;
                map[guardY][guardX] = '^';
            }

            if (next == '#')
            {
                (velX, velY) = rotate90(velX, velY);
            }

            PrintMap(map);
        }

        return 0;
    }

    private bool guardInBounds(char[][] map, int guardX, int guardY) =>
        guardX >= 0 && guardX < map[0].Length &&
        guardY >= 0 && guardY < map.Length;


    private (int x, int y) rotate90(int x, int y) =>
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