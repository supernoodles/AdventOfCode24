namespace Tests;

public class Part1Tests
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

        var result = Code.Day12.Part1(input.Split(Environment.NewLine));

        Assert.Equal(140, result);
    }

    [Fact]
    public void Test2()
    {
        var input = """
OOOOO
OXOXO
OOOOO
OXOXO
OOOOO
""";

        var result = Code.Day12.Part1(input.Split(Environment.NewLine));

        Assert.Equal(772, result);
    }

[Fact]
    public void Test3()
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

        var result = Code.Day12.Part1(input.Split(Environment.NewLine));

        Assert.Equal(1930, result);
    }}
