namespace tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var day9 = new code.Day9();

        var input = "12345";
        
        Assert.Equal("0..111....22222", day9.Part1(input));
    }
}
