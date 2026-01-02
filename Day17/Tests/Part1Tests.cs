namespace Tests;

public class Part1Tests
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

        Assert.Equal("", Code.Day17.Part1(input.Split(Environment.NewLine)));
    }
}