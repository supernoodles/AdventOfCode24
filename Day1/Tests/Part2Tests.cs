namespace Day1.Tests;

using Xunit;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var input = """
        3   4
        4   3
        2   5
        1   3
        3   9
        3   3
        """;

        var day1 = new Day1();

        Assert.Equal(31, day1.Part2(input.Split(Environment.NewLine)));
    }
}
