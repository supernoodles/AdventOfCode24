// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 13!");

var input = await File.ReadAllLinesAsync("input.txt");

Console.WriteLine($"Part 1: {Code.Day13.Part1(input)}");
//Console.WriteLine($"Part 2: {Code.Day13.Part2(input)}");
