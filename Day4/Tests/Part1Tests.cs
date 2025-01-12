namespace Tests;

public class Part1Tests
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

        Assert.Equal(18, day4.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test2()
    {
        var day4 = new Code.Day4();

        var input = """
        X.....X
        .M...M.
        ..A.A..
        ...S...
        ..A.A..
        .M...M.
        X.....X
        """;

        Assert.Equal(4, day4.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test3()
    {
        var day4 = new Code.Day4();

        var input = """
        S.....S
        .A...A.
        ..M.M..
        ...X...
        ..M.M..
        .A...A.
        S.....S
        """;

        Assert.Equal(4, day4.Part1(input.Split("\n")));
    }
}
