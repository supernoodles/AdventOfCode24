namespace tests;

public class Part1Tests
{
    [Fact]
    public void Test1()
    {
        var day8 = new code.Day8();

        // a[4,3] = 34
        // a[5,5] = 55

        // p1[6,7] = 76
        // p2[3,1] = 13

        var input = """
..........
...#......
..........
....a.....
..........
.....a....
..........
......#...
..........
..........
""";

        var locations = day8.Part1(input.Split("\n"));

        Assert.Contains(new code.Location(6, 7), locations);
        Assert.Contains(new code.Location(3, 1), locations);

        //Assert.Equal(0, day8.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test2()
    {
        var day8 = new code.Day8();

        // a0[6,3] = 36
        // a1[5,5] = 55

        // p1[4,7] = 74
        // p2[7,1] = 17

        var input = """
..........
.......#..
..........
......a...
..........
.....a....
..........
....#.....
..........
..........
""";

        var locations = day8.Part1(input.Split("\n"));

        Assert.Contains(new code.Location(4, 7), locations);
        Assert.Contains(new code.Location(7, 1), locations);

        //Assert.Equal(0, day8.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test3()
    {
        var day8 = new code.Day8();

        // a0[3,1] = 13
        // a1[6,1] = 16 dx = 3, dy = 0

        // p1[0,1] = 10
        // p2[9,1] = 19

        var input = """
..........
#..a..a..#
..........
..........
..........
..........
..........
..........
..........
..........
""";

        var locations = day8.Part1(input.Split("\n"));

        Assert.Contains(new code.Location(0, 1), locations);
        Assert.Contains(new code.Location(9, 1), locations);

        //Assert.Equal(0, day8.Part1(input.Split("\n")));
    }

    [Fact]
    public void Test4()
    {
        var day8 = new code.Day8();

        // a0[4,3] = 34
        // a1[4,5] = 54 dx = 0, dy = 2

        // p1[4,1] = 14
        // p2[4,7] = 74

        var input = """
..........
....#.....
..........
....a.....
..........
....a.....
..........
....#.....
..........
..........
""";

        var locations = day8.Part1(input.Split("\n"));

        Assert.Contains(new code.Location(4, 1), locations);
        Assert.Contains(new code.Location(4, 7), locations);

        //Assert.Equal(0, day8.Part1(input.Split("\n")));
    }
}
