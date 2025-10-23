namespace Code;

public class Day10
{
    public static int Part1(string[] input) => FindTrailScore(input, true);

    public static int Part2(string[] input) => FindTrailScore(input, false);

    private record Position(int X, int Y);

    public static int FindTrailScore(string[] input, bool distinct)
    {
        var width = input[0].Length;
        var height = input.Length;

        char[][] map = [.. input.Select(s => s.ToCharArray())];

        var score = 0;

        for (int row = 0; row < height; ++row)
        {
            for (int col = 0; col < width; ++col)
            {
                if (map[row][col] != '0')
                {
                    continue;
                }

                score += distinct
                    ? RecursePath(map, width, height, col, row).Distinct().Count()
                    : RecursePath(map, width, height, col, row).Count;
            }
        }

        return score;
    }

    private readonly static List<Position> searchOffsets =
        [
            new Position(0, -1),
            new Position(-1, 0), new Position(1, 0),
            new Position(0, 1)
        ];

    private static List<Position?> FindNextHeightPositions(char[][] map, int width, int height, int currentX, int currentY) =>
        [.. searchOffsets.Select(offset =>
        {
            var nextX = currentX + offset.X;
            var nextY = currentY + offset.Y;

            if (nextX < 0 || nextX >= width || nextY < 0 || nextY >= height)
            {
                return null;
            }

            return map[nextY][nextX] == map[currentY][currentX] + 1
                ? new Position(nextX, nextY)
                : null;
        })];

    private static List<Position?> RecursePath(char[][] map, int width, int height, int currentX, int currentY)
    {
        var nextPositions = FindNextHeightPositions(map, width, height, currentX, currentY).Where(_ => _ != null).ToList();

        if (nextPositions.Count == 0)
        {
            return [];
        }

        if(map[currentY][currentX] == '8')
        {
            return nextPositions;
        }

        return [.. nextPositions.SelectMany(next => RecursePath(map, width, height, next?.X ?? -1 , next?.Y ?? -1))];
    }
}