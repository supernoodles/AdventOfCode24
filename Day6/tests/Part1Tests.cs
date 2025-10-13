namespace tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var day6 = new code.Day6();

        var input = """
....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
""";

        Assert.Equal(0, day6.Part1(input.Split("\r\n")));
    }
}
