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
}