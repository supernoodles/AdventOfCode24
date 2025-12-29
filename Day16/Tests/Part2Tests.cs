namespace Tests;

public class Part2Tests()
{
    [Fact]
    public void Test1()
    {
        var input = """
####
##E#
#S.#
####
""";

        Assert.Equal(3, Code.Day16.Part2(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Test2()
    {
        var input = """
####
#.E#
#S##
####
""";

        Assert.Equal(3, Code.Day16.Part2(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Test3()
    {
        var input = """
#####
##.E#
#S.##
#####
""";

        Assert.Equal(4, Code.Day16.Part2(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Test4()
    {
        var input = """
######
##..E#
##.###
#S..##
######
""";

        Assert.Equal(6, Code.Day16.Part2(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Example1()
    {
        var input = """
###############
#.......#....E#
#.#.###.#.###.#
#.....#.#...#.#
#.###.#####.#.#
#.#.#.......#.#
#.#.#####.###.#
#...........#.#
###.#.#####.#.#
#...#.....#.#.#
#.#.#.###.#.#.#
#.....#...#.#.#
#.###.#.#.#.#.#
#S..#.....#...#
###############
""";

        Assert.Equal(45, Code.Day16.Part2(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Example2()
    {
        var input = """
#################
#...#...#...#..E#
#.#.#.#.#.#.#.#.#
#.#.#.#...#...#.#
#.#.#.#.###.#.#.#
#...#.#.#.....#.#
#.#.#.#.#.#####.#
#.#...#.#.#.....#
#.#.#####.#.###.#
#.#.#.......#...#
#.#.###.#####.###
#.#.#...#.....#.#
#.#.#.#####.###.#
#.#.#.........#.#
#.#.#.#########.#
#S#.............#
#################
""";

        Assert.Equal(64, Code.Day16.Part2(input.Split(Environment.NewLine)));
    }
}
