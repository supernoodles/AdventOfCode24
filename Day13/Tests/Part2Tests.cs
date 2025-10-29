namespace Tests;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var input = """
Button A: X+26, Y+66
Button B: X+67, Y+21
Prize: X=10000000012748, Y=10000000012176
""";

        Assert.Equal(459236326669, Code.Day13.Part1(input.Split(Environment.NewLine)));
    }

    [Fact]
    public void Test2()
    {
        var input = """
Button A: X+94, Y+34
Button B: X+22, Y+67
Prize: X=10000000008400, Y=10000000005400

Button A: X+26, Y+66
Button B: X+67, Y+21
Prize: X=10000000012748, Y=10000000012176

Button A: X+17, Y+86
Button B: X+84, Y+37
Prize: X=10000000007870, Y=10000000006450

Button A: X+69, Y+23
Button B: X+27, Y+71
Prize: X=10000000018641, Y=10000000010279
""";

        Assert.Equal(875318608908, Code.Day13.Part1(input.Split(Environment.NewLine)));
    }
}
