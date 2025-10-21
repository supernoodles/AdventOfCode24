namespace tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var day9 = new code.Day9();

        var input = "12345";

        Assert.Equal(60, day9.Part1(input));
    }

    [Fact]
    public void Test2()
    {
        var day9 = new code.Day9();

        var input = "2333133121414131402";
        
        //00...111...2...333.44.5555.6666.777.888899

        Assert.Equal(1928, day9.Part1(input));
    }
}
