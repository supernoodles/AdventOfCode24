namespace Tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var input = """
p=2,4 v=2,-3
""";
        Assert.Equal(0, Code.Day14.Part1(input.Split(Environment.NewLine), 11, 7, 5));
    }

    [Fact]
    public void Test2()
    {
        var input = """
p=0,4 v=3,-3
p=6,3 v=-1,-3
p=10,3 v=-1,2
p=2,0 v=2,-1
p=0,0 v=1,3
p=3,0 v=-2,-2
p=7,6 v=-1,-3
p=3,0 v=-1,-2
p=9,3 v=2,3
p=7,3 v=-1,2
p=2,4 v=2,-3
p=9,5 v=-3,-3
""";
        Assert.Equal(12, Code.Day14.Part1(input.Split(Environment.NewLine), 11, 7, 100));
    }
}
