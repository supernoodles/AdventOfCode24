namespace tests;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var day8 = new code.Day8();

        var input = """
T....#....
...T......
.T....#...
.........#
..#.......
..........
...#......
..........
....#.....
..........
""";

        var locations = day8.Part2(input.Split("\n"));

        Assert.Equal(9, locations.Count);
    }

    [Fact]
    public void Test2()
    {
        var day8 = new code.Day8();

        var input = """
##....#....#
.#.#....0...
..#.#0....#.
..##...0....
....0....#..
.#...#A....#
...#..#.....
#....#.#....
..#.....A...
....#....A..
.#........#.
...#......##
""";

        var locations = day8.Part2(input.Split("\n"));

        Assert.Equal(34, locations.Count);
    }
}