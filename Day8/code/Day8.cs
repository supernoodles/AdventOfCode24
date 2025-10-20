namespace code;

public record Location(int X, int Y);

public class Day8
{
    public List<Location> Part1(string[] input)
    {
        var width = input[0].Length;
        var height = input.Length;

        char[] map = [.. input.SelectMany(row => row.ToArray())];

        var antennaFrequencies = map.Where(_ => _ != '.' && _ != '#').Distinct().ToList();

        List<Location> antinodes = [];

        foreach (var antennaFrequency in antennaFrequencies)
        {
            var antennaLocations = map
                .Index()
                .Where(location => location.Item == antennaFrequency)
                .Select(_ => _.Index).ToList();

            var antennaPairs = antennaLocations
                .SelectMany(item =>
                    antennaLocations.Select(item2 =>
                        item2 != item
                            ? item < item2
                                ? new { First = item, Second = item2 }
                                : new { First = item2, Second = item }
                            : null))
                .Where(_ => _ != null)
                .Distinct()
                .ToList();

            foreach (var pair in antennaPairs)
            {
                var dx = pair!.Second % width - pair.First % width;
                var dy = pair.Second / height - pair.First / height;

                var p1x = (pair.Second % width) + dx;
                var p1y = (pair.Second / height) + dy;

                var p2x = (pair.First % width) - dx;
                var p2y = (pair.First / height) - dy;

                StoreAntiNodeOnMap(width, height, antinodes, p1x, p1y);
                StoreAntiNodeOnMap(width, height, antinodes, p2x, p2y);
            }
        }

        return [.. antinodes.Distinct()];
    }

    public List<Location> Part2(string[] input)
    {
        var width = input[0].Length;
        var height = input.Length;

        char[] map = [.. input.SelectMany(row => row.ToArray())];

        var antennaFrequencies = map.Where(_ => _ != '.' && _ != '#').Distinct().ToList();

        List<Location> antinodes = [];

        foreach (var antennaFrequency in antennaFrequencies)
        {
            var antennaLocations = map
                .Index()
                .Where(location => location.Item == antennaFrequency)
                .Select(_ => _.Index).ToList();

            var antennaPairs = antennaLocations
                .SelectMany(item =>
                    antennaLocations.Select(item2 =>
                        item2 != item
                            ? item < item2
                                ? new { First = item, Second = item2 }
                                : new { First = item2, Second = item }
                            : null))
                .Where(_ => _ != null)
                .Distinct()
                .ToList();

            foreach (var pair in antennaPairs)
            {
                var dx = pair!.Second % width - pair.First % width;
                var dy = pair.Second / height - pair.First / height;

                var p1x = pair.Second % width;
                var p1y = pair.Second / height;

                while (StoreAntiNodeOnMap(width, height, antinodes, p1x, p1y))
                {
                    p1x += dx;
                    p1y += dy;
                }

                var p2x = pair.First % width;
                var p2y = pair.First / height;

                while (StoreAntiNodeOnMap(width, height, antinodes, p2x, p2y))
                {
                    p2x -= dx;
                    p2y -= dy;
                }    
            }
        }

        return [.. antinodes.Distinct()];
    }

    private static bool StoreAntiNodeOnMap(int width, int height, List<Location> antinodes, int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            antinodes.Add(new Location(x, y));

            return true;
        }

        return false;
    }
}