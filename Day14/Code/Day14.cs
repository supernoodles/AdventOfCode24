using System.Text.RegularExpressions;

namespace Code;

public partial class Day14
{
    private class Robot(int PX, int PY, int VX, int VY)
    {
        public int PX { get; set; } = PX;
        public int PY { get; set; } = PY;
        public int VX { get; set; } = VX;
        public int VY { get; set; } = VY;
    }

    private readonly static Regex LineRegex = LRegex();

    public static int Part1(string[] input, int width, int height, int iterations)
    {
        List<Robot> robots = ParseRobots(input);

        for (int timestep = 0; timestep < iterations; ++timestep)
        {
            foreach (var robot in robots)
            {
                robot.PX = (width + robot.PX + robot.VX) % width;
                robot.PY = (height + robot.PY + robot.VY) % height;
            }
        }

        var q1 = robots.Where(r => (r.PX < width / 2) && (r.PY < height / 2)).Count();
        var q2 = robots.Where(r => (r.PX > width / 2) && (r.PY < height / 2)).Count();
        var q3 = robots.Where(r => (r.PX < width / 2) && (r.PY > height / 2)).Count();
        var q4 = robots.Where(r => (r.PX > width / 2) && (r.PY > height / 2)).Count();

        return q1 * q2 * q3 * q4;
    }

    public static int Part2(string[] input, int width, int height)
    {
        List<Robot> robots = ParseRobots(input);

        var timestep = 0;

        bool run = true;

        var colRunMax = 0;

        while (run)
        {
            foreach (var robot in robots)
            {
                robot.PX = (width + robot.PX + robot.VX) % width;
                robot.PY = (height + robot.PY + robot.VY) % height;
            }

            ++timestep;

            var ordered = robots.GroupBy(r => r.PX);

            foreach (var row in ordered)
            {
                var items = row.OrderBy(r => r.PY);

                int max = 1;
                int count = 1;

                var _ = items.Skip(1).Aggregate(items.First().PY, (prev, item) =>
                {
                    count = item.PY == prev + 1 ? count + 1 : 1;
                    if (count > max)
                    {
                        max = count;
                    }
                    return item.PY;
                });

                if (max > colRunMax)
                {
                    colRunMax = max;
                }
            }

            if (colRunMax > 20)
            {
                run = false;

                VisualizeRobots(robots);
            }
        }

        return timestep;
    }

    private static void VisualizeRobots(List<Robot> robots)
    {
        char[] output = [.. Enumerable.Repeat('.', 103 * 101)];

        foreach (var r in robots)
        {
            output[r.PY * 101 + r.PX] = '*';
        }

        for (int row = 0; row < 103; row++)
        {
            Console.WriteLine($"{new string([.. output.Skip(row * 101).Take(101)])}");
        }
    }

    private static List<Robot> ParseRobots(string[] input) =>
        [.. input.Select(line =>
        {
            var match = LineRegex.Match(line);

            return new Robot(
                int.Parse(match.Groups["px"].Value),
                int.Parse(match.Groups["py"].Value),
                int.Parse(match.Groups["vx"].Value),
                int.Parse(match.Groups["vy"].Value));
        })];

    [GeneratedRegex(@"^p=(?<px>\d*?),(?<py>\d*?) v=(?<vx>-?\d*?),(?<vy>-?\d*?)$")]
    private static partial Regex LRegex();
}