
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

                var area = 0;

                var perim = Recurse(map, visited, map[row][col], row, col, ref area);

                totalPrice += perim * area;
            }
        }

        return totalPrice;
    }

    private static bool IsInBounds(char[][] map, int row, int col) =>
        row >= 0 && row < map.Length && col >= 0 && col < map[0].Length;

    private static int Recurse(char[][] map, HashSet<(int, int)> visited, char plant, int row, int col, ref int area)
    {
        if (!IsInBounds(map, row, col) || map[row][col] != plant)
        {
            return 1;
        }

        if (visited.Contains((row, col)) && map[row][col] == plant)
        {
            return 0;
        }

        visited.Add((row, col));
        area += 1;

        return
            Recurse(map, visited, plant, row - 1, col, ref area) +
            Recurse(map, visited, plant, row, col + 1, ref area) +
            Recurse(map, visited, plant, row + 1, col, ref area) +
            Recurse(map, visited, plant, row, col - 1, ref area);
    }

    public static int Part2(string[] input)
    {
        // Implementation for Part 2
        return 0;
    }
}