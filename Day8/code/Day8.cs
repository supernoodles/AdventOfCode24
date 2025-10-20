namespace code;

public record Location(int X, int Y);

public class Day8
{
    private record LocationPair(Location First, Location Second);

    public List<Location> Part1(string[] input)
    {
        var width = input[0].Length;
        var height = input.Length;

        char[] map = [.. input.SelectMany(row => row.ToArray())];

        var antennaFrequencies = map.Where(_ => _ != '.' && _ != '#').Distinct().ToList();

        List<Location> antinodes = [];

        foreach (var antennaFrequency in antennaFrequencies)
        {
            List<int> antennaLocations = FindAntennaLocationsForFrequency(map, antennaFrequency);

            var antennaPairs = FindAntennaLocationPairs(width, height, antennaLocations);

            foreach (var pair in antennaPairs)
            {
                var dx = pair!.Second.X - pair.First.X;
                var dy = pair.Second.Y - pair.First.Y;

                var p1x = pair.Second.X + dx;
                var p1y = pair.Second.Y + dy;

                var p2x = pair.First.X - dx;
                var p2y = pair.First.Y - dy;

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
            var antennaLocations = FindAntennaLocationsForFrequency(map, antennaFrequency);

            var antennaPairs = FindAntennaLocationPairs(width, height, antennaLocations);

            foreach (var pair in antennaPairs)
            {
                var dx = pair!.Second.X - pair.First.X;
                var dy = pair.Second.Y - pair.First.Y;

                var p1x = pair.Second.X;
                var p1y = pair.Second.Y;

                while (StoreAntiNodeOnMap(width, height, antinodes, p1x, p1y))
                {
                    p1x += dx;
                    p1y += dy;
                }

                var p2x = pair.First.X;
                var p2y = pair.First.Y;

                while (StoreAntiNodeOnMap(width, height, antinodes, p2x, p2y))
                {
                    p2x -= dx;
                    p2y -= dy;
                }
            }
        }

        return [.. antinodes.Distinct()];
    }

    private static List<int> FindAntennaLocationsForFrequency(char[] map, char antennaFrequency) =>
        [.. map
            .Index()
            .Where(location => location.Item == antennaFrequency)
            .Select(_ => _.Index)];

    private static Location LocationFromIndex(int index, int width, int height) =>
        new(index % width, index / height);

    private static List<LocationPair?> FindAntennaLocationPairs(int width, int height, List<int> antennaLocations) =>
        [.. antennaLocations
            .SelectMany(location =>
                antennaLocations.Select(location2 =>
                    location2 != location
                        ? location < location2
                            ? new LocationPair
                            (
                                LocationFromIndex(location, width, height),
                                LocationFromIndex(location2, width, height)
                            )
                            : new LocationPair
                            (
                                LocationFromIndex(location2, width, height),
                                LocationFromIndex(location, width, height)
                            )
                        : null))
            .Where(_ => _ != null)
            .Distinct()];

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