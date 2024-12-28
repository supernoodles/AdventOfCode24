using Code;

namespace Tests;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var day2 = new Code.Day2();

        var input = """
        7 6 4 2 1
        1 2 7 8 9
        9 7 6 2 1
        1 3 2 4 5
        8 6 4 4 1
        1 3 6 7 9
        """;

        Assert.Equal(4, day2.Part2(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Test2a()
    {
        Day2 day2 = new ();

        var input = """
        9 8 7 7 7
        """;

        Assert.Equal(0, day2.Part2(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Test2()
    {
        var day2 = new Code.Day2();

        var input = """
        48 46 47 49 51 54 56
        1 1 2 3 4 5
        1 2 3 4 5 5
        5 1 2 3 4 5
        1 4 3 2 1
        1 6 7 8 9
        1 2 3 4 3
        9 8 7 6 7
        7 10 8 10 11
        29 28 27 25 26 25 22 20
        9 8 7 7 7
        """;

        Assert.Equal(10, day2.Part2(input.Split(Environment.NewLine)));
    }
}
