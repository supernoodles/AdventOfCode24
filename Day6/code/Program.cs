// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 6!");

var testInput = """
....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
""";

var day6 = new code.Day6();

var input = File.ReadAllLines("input.txt");

// Console.WriteLine($"Part1={day6.Part1(testInput.Split("\n"))}");

// Console.WriteLine($"Part1={day6.Part1(input)}");

// Console.WriteLine($"Part2 test = {day6.Part2(testInput.Split("\n"))}");

Console.WriteLine($"Part2 = {day6.Part2(input)}");