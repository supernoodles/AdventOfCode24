namespace Tests;

public class PartTest1
{
    [Fact]
    public void Test1()
    {
        var day10 = new Code.Day10();

        var input = """
Stuff
""";

        Assert.Equal(0, day10.Part1(input.Split("\n")));
    }
}
