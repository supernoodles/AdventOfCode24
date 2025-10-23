namespace Tests;

public class PartTest2
{
    [Fact]
    public void Test1()
    {
        var day10 = new Code.Day10();

        var input = """
.....0.
..4321.
..5..2.
..6543.
..7..4.
..8765.
..9....
""";

        Assert.Equal(3, Code.Day10.Part2(input.Split("\n")));
    }

    [Fact]
    public void Test2()
    {
        var day10 = new Code.Day10();

        var input = """
..90..9
...1.98
...2..7
6543456
765.987
876....
987....
""";

        Assert.Equal(13, Code.Day10.Part2(input.Split("\n")));
    }

    [Fact]
    public void Test3()
    {
        var day10 = new Code.Day10();

        var input = """
012345
123456
234567
345678
4.6789
56789.
""";

        Assert.Equal(227, Code.Day10.Part2(input.Split("\n")));
    }

    [Fact]
    public void Test4()
    {
        var day10 = new Code.Day10();

        var input = """
89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732
""";

        Assert.Equal(81, Code.Day10.Part2(input.Split("\n")));
    }
}
