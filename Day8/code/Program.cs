// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day 8!");

var input = File.ReadAllLines("input.txt");

var day7 = new code.Day8();

Console.WriteLine($"Part1 = {day7.Part1(input).Count}");

// Console.WriteLine($"Part2 = {day7.Part2(input)}");
