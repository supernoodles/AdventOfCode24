using System.Text.RegularExpressions;

namespace Code;

public partial class Day14
{
    private class Robot
    {
        public int PX { get; set; }
        public int PY { get; set; }
        public int VX { get; set; }
        public int VY { get; set; }
    }

    private readonly static Regex LineRegex = LRegex();

    public static int Part1(string[] input, int width, int height, int iterations)
    {
        var robots = input.Select(line =>
        {
            var match = LineRegex.Match(line);

            return new Robot
            {
                PX = int.Parse(match.Groups["px"].Value),
                PY = int.Parse(match.Groups["py"].Value),
                VX = int.Parse(match.Groups["vx"].Value),
                VY = int.Parse(match.Groups["vy"].Value),
            };
        }).ToList();

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

    [GeneratedRegex(@"^p=(?<px>\d*?),(?<py>\d*?) v=(?<vx>-?\d*?),(?<vy>-?\d*?)$")]
    private static partial Regex LRegex();
}