
namespace Code;

public static class Day12
{
    public static int Part1(string[] input)
    {
        char[][] map = [.. input.Select(line => line.ToCharArray())];

        HashSet<(int, int)> visited = [];

        var totalPrice = 0;

        for (int row = 0; row < map.Length; row++)
        {
            for (int col = 0; col < map[0].Length; col++)
            {
                if (visited.Contains((row, col)))
                {
                    continue;
                }

                totalPrice += Recurse(map, visited, map[row][col], row, col);
            }
        }

        return 0;
    }

    private static bool IsInBounds(char[][] map, int row, int col) =>
        row >= 0 && row < map.Length && col >= 0 && col < map[0].Length;

    private static int Recurse(char[][] map, HashSet<(int, int)> visited, char plant, int row, int col)
    {
        if (visited.Contains((row, col)))
        {
            return 0;
        }

        if (!IsInBounds(map, row, col) || map[row][col] != plant)
        {
            return 1;
        }

        visited.Add((row, col));

        return Recurse(map, visited, plant, row + 1, col) +
               Recurse(map, visited, plant, row - 1, col) +
               Recurse(map, visited, plant, row, col + 1) +
               Recurse(map, visited, plant, row, col - 1);
    }

    public static int Part2(string[] input)
    {
        // Implementation for Part 2
        return 0;
    }
}