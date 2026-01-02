namespace Tests;

public class Part1Tests
{
    [Fact]
    public void TestBst()
    {
        var computer = new Code.Computer
        {
            RegisterC = 9,
            Program = [2, 6]
        };

        computer.Run();

        Assert.Equal(1, computer.RegisterB);
    }

    [Fact]
    public void TestAdv()
    {
        var computer = new Code.Computer
        {
            RegisterB = 29,
            Program = [1, 7]
        };

        computer.Run();

        Assert.Equal(26, computer.RegisterB);
    }

    [Fact]
    public void TestBxc()
    {
        var computer = new Code.Computer
        {
            RegisterB = 2024,
            RegisterC = 43690,
            Program = [4, 0]
        };

        computer.Run();

        Assert.Equal(44354, computer.RegisterB);
    }

    [Theory]
    [InlineData("0,1,2", "Register A: 10\nRegister B: 0\nRegister C: 0\n\nProgram: 5,0,5,1,5,4")]
    [InlineData("4,2,5,6,7,7,7,7,3,1,0", "Register A: 2024\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1,5,4,3,0")]
    public void Examples(string expected, string input)
    {
        var lines = input.Split(Environment.NewLine);
        Assert.Equal(expected, Code.Day17.Part1(lines));
    }

    [Fact]
    public void Test1()
    {
        var input = """
Register A: 729
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0
""";

        Assert.Equal("4,6,3,5,6,3,5,2,1,0", Code.Day17.Part1(input.Split(Environment.NewLine)));
    }
}