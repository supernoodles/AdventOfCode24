// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day3!");

var input = File.ReadAllText("input.txt");

Console.WriteLine($"Part1 = {Code.Day3.Part1(input)}");

Console.WriteLine($"Part2 = {Code.Day3.Part2(input)}");
