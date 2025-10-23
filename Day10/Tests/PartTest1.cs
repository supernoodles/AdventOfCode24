namespace Tests;

public class PartTest1
{
    [Fact]
    public void Test1()
    {
        var day10 = new Code.Day10();

        var input = """
0123
1234
8765
9876
""";

        Assert.Equal(1, Code.Day10.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test2()
    {
        var day10 = new Code.Day10();

        var input = """
...0...
...1...
...2...
6543456
7.....7
8.....8
9.....9
""";

        Assert.Equal(2, Code.Day10.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test3()
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

        Assert.Equal(4, Code.Day10.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test4()
    {
        var day10 = new Code.Day10();

        var input = """
10..9..
2...8..
3...7..
4567654
...8..3
...9..2
.....01
""";

        Assert.Equal(3, Code.Day10.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test5()
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

        Assert.Equal(36, Code.Day10.Part1(input.Split("\n")));
    }
}
