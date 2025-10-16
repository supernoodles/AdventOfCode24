namespace tests;

public class Part2Tests
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

        Assert.Equal(6, day6.Part2(input.Split("\n")));
    }
}
