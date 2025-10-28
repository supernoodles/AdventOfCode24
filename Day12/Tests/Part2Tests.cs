namespace Tests;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var input = """
AAAA
BBCD
BBCC
EEEC
""";

        var result = Code.Day12.Part2(input.Split(Environment.NewLine));

        Assert.Equal(80, result);
    }

    [Fact]
    public void Test2()
    {
        var input = """
EEEEE
EXXXX
EEEEE
EXXXX
EEEEE
""";

        var result = Code.Day12.Part2(input.Split(Environment.NewLine));

        Assert.Equal(236, result);
    }

    [Fact]
    public void Test3()
    {
        var input = """
AAAAAA
AAABBA
AAABBA
ABBAAA
ABBAAA
AAAAAA
""";

        var result = Code.Day12.Part2(input.Split(Environment.NewLine));

        Assert.Equal(368, result);
    }

    [Fact]
    public void Test4()
    {
        var input = """
RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE
""";

        var result = Code.Day12.Part2(input.Split(Environment.NewLine));

        Assert.Equal(1206, result);
    }
}