namespace tests;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var day9 = new code.Day9();

        var input = "2333133121414131402";
        
        Assert.Equal(2858, day9.Part2(input));
    }
}
