// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day15!");

// var input2 = """
// ######
// ##..E#
// ##.###
// #S..##
// ######
// """;

// var input = """
// ###############
// #.......#....E#
// #.#.###.#.###.#
// #.....#.#...#.#
// #.###.#####.#.#
// #.#.#.......#.#
// #.#.#####.###.#
// #...........#.#
// ###.#.#####.#.#
// #...#.....#.#.#
// #.#.#.###.#.#.#
// #.....#...#.#.#
// #.###.#.#.#.#.#
// #S..#.....#...#
// ###############
// """;

// Console.WriteLine($"Part 1: {Code.Day16.Part2(input.Split(Environment.NewLine))}");

var input = await File.ReadAllLinesAsync("input.txt");
Console.WriteLine($"Part 1: {Code.Day16.Part1(input)}");
Console.WriteLine($"Part 2: {Code.Day16.Part2(input)}");
