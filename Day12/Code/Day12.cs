namespace Code;

public static class Day12
{
    public static int Part1(string[] input)
    {
        char[][] map = [.. input.Select(line => line.ToCharArray())];

        HashSet<(int, int)> visited = [];

        return
            map.SelectMany((row, ri) =>
                row.Select((col, ci) =>
                {
                    if (visited.Contains((ri, ci)))
                    {
                        return 0;
                    }

                    var area = 0;

                    var perim = Recurse(map, visited, map[ri][ci], ri, ci, ref area);

                    return perim * area;
                }))
            .Sum();
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
        char[][] map = [.. input.Select(line => line.ToCharArray())];

        HashSet<(int, int)> visited = [];

        return
            map.SelectMany((row, ri) =>
                row.Select((col, ci) =>
                {
                    if (visited.Contains((ri, ci)))
                    {
                        return 0;
                    }

                    var area = 0;
                    var corners = 0;

                    RecurseCorners(map, visited, map[ri][ci], ri, ci, ref area, ref corners);

                    return corners * area;
                }))
            .Sum();
    }

    private static void RecurseCorners(char[][] map, HashSet<(int, int)> visited, char plant, int row, int col, ref int area, ref int corners)
    {
        if (!IsInBounds(map, row, col) ||
            map[row][col] != plant ||
            (visited.Contains((row, col)) && map[row][col] == plant))
        {
            return;
        }

        visited.Add((row, col));
        area += 1;

        // Offsets for left, top and left-top cells (will be rotated!)
        var (ldx, ldy) = (-1, 0);
        var (tdx, tdy) = (0, -1);
        var (ltdx, ltdy) = (-1, -1);

        for (int turns = 0; turns < 4; ++turns)
        {
            if (
                (!IsInBounds(map, row + ldy, col + ldx) || map[row + ldy][col + ldx] != plant) &&
                (!IsInBounds(map, row + tdy, col + tdx) || map[row + tdy][col + tdx] != plant)
            )
            {
                // Convex corner
                // ?B
                // BA
                corners += 1;
            }

            if (
                IsInBounds(map, row + ldy, col + ldx) && map[row + ldy][col + ldx] == plant &&
                IsInBounds(map, row + tdy, col + tdx) && map[row + tdy][col + tdx] == plant &&
                IsInBounds(map, row + ltdy, col + ltdx) && map[row + ltdy][col + ltdx] != plant
            )
            {
                // Concave corner
                // BA
                // AA
                corners += 1;
            }

            // Rotate to check next diagonal for a corner
            (ldx, ldy) = Rotate90(ldx, ldy);
            (tdx, tdy) = Rotate90(tdx, tdy);
            (ltdx, ltdy) = Rotate90(ltdx, ltdy);
        }
        
        // Flood fill to find the rest of the shape
        RecurseCorners(map, visited, plant, row - 1, col, ref area, ref corners);
        RecurseCorners(map, visited, plant, row, col + 1, ref area, ref corners);
        RecurseCorners(map, visited, plant, row + 1, col, ref area, ref corners);
        RecurseCorners(map, visited, plant, row, col - 1, ref area, ref corners);
    }
    
    private static (int x, int y) Rotate90(int x, int y) =>
        (-y,
        x);
}