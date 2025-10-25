// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day11!");

var input = File.ReadAllText("input.txt");

var day11 = new Code.Day11();

Console.WriteLine($"Part1 = {day11.Part1(input)}");

Console.WriteLine($"Part2 = {day11.Part2(input)}");
