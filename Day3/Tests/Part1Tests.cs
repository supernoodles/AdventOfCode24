namespace Tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var input = """
        xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)
        +mul(32,64]then(mul(11,8)mul(8,5))
        """;

        Assert.Equal(161, Code.Day3.Part1(input));
    }
}
