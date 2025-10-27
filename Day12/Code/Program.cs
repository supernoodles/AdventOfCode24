// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 12!");

var input = await File.ReadAllLinesAsync("input.txt");

Console.WriteLine($"Part 1: {Code.Day12.Part1(input)}");
Console.WriteLine($"Part 2: {Code.Day12.Part2(input)}");
