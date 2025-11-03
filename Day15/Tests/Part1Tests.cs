namespace Tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var input = """
########
#..O.O.#
##@.O..#
#...O..#
#.#.O..#
#...O..#
#......#
########

<^^>>>vv<v>>v<<
""";
        Assert.Equal(2028, Code.Day15.Part1(input.Split(Environment.NewLine)));
    }
}
