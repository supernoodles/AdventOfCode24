using System.Security.Cryptography.X509Certificates;

namespace code;

public record Location(int X, int Y);

public class Day8
{

    public List<Location> Part1(string[] input)
    {
        var width = input[0].Length;
        var height = input.Length;

        char[] map = [.. input.SelectMany(row => row.ToArray())];

        var antennas = map.Where(_ => _ != '.' && _ != '#').Distinct().ToList();

        var antenna = antennas.First();

        var locations = map.Index().Where(location => location.Item == antenna).Select(_ => _.Index).ToList();

        var dx = locations[1] % width - locations[0] % width;
        var dy = locations[1] / height - locations[0] / height;

        var p1x = (locations[1] % 10) + dx;
        var p1y = (locations[1] / 10) + dy;

        var p2x = (locations[0] % 10) - dx;
        var p2y = (locations[0] / 10) - dy;

        return [
            new Location(p1x, p1y),
            new Location(p2x, p2y)
        ];
    }
}