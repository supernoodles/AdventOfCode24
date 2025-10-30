// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 14!");

var input = await File.ReadAllLinesAsync("input.txt");

Console.WriteLine($"Part 1: {Code.Day14.Part1(input, 101, 103, 100)}");
// Console.WriteLine($"Part 2: {Code.Day14.Part2(input)}");
