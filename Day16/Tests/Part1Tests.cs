namespace Tests;

public class Part1Tests()
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

        Assert.Equal(1002, Code.Day16.Part1(input.Split(Environment.NewLine)));
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

        Assert.Equal(2002, Code.Day16.Part1(input.Split(Environment.NewLine)));
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

        Assert.Equal(2003, Code.Day16.Part1(input.Split(Environment.NewLine)));
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

        Assert.Equal(2005, Code.Day16.Part1(input.Split(Environment.NewLine)));
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

        Assert.Equal(7036, Code.Day16.Part1(input.Split(Environment.NewLine)));
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

        Assert.Equal(11048, Code.Day16.Part1(input.Split(Environment.NewLine)));
    }
}
