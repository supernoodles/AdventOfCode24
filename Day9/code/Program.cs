// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 9!");

var input = File.ReadAllLines("input.txt");

var day9 = new code.Day9();

Console.WriteLine($"Part1 = {day9.Part1(input.First())}");

// Console.WriteLine($"Part2 = {day9.Part2(input).Count}");

