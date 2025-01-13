namespace Tests;

public class Part2Tests
{
    [Fact]
    public void Test1()
    {
        var day4 = new Code.Day4();

        var input = """
        MMMSXXMASM
        MSAMXMSMSA
        AMXSXMAAMM
        MSAMASMSMX
        XMASAMXAMM
        XXAMMXXAMA
        SMSMSASXSS
        SAXAMASAAA
        MAMMMXMMMM
        MXMXAXMASX
        """;

        Assert.Equal(9, day4.Part2(input.Split("\n")));
    }

    [Fact]
    public void Test2()
    {
        var day4 = new Code.Day4();

        var input = """
        M.S
        .A.
        M.S
        """;

        Assert.Equal(1, day4.Part2(input.Split("\n")));
    }
}
