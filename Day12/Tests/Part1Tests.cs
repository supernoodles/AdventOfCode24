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
}
