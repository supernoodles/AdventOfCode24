namespace Tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var day11 = new Code.Day11();

        var input = "125 17";

        Assert.Equal(55312, day11.Part1(input));
    }
}
