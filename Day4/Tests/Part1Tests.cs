namespace Tests;

public class UnitTest1
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

        Assert.Equal(1, day4.Part1(input.Split("\n")));
    }
}
