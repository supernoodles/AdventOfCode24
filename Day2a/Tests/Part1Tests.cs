namespace Tests;

public class Part1Tests
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

        Assert.Equal(2, day2.Part1(input.Split(Environment.NewLine)));
    }
}
