Console.WriteLine("Hello, Day17!");

var input = await File.ReadAllLinesAsync("input.txt");
Console.WriteLine($"Part 1: {Code.Day17.Part1(input)}");
Console.WriteLine($"Part 2: {Code.Day17.Part2(input)}");
