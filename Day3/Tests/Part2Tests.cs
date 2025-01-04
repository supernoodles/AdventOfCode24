namespace Tests;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var day3 = new Code.Day3();

        var input = """
        xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
        """;

        Assert.Equal(48, day3.Part2(input));
    }
}
